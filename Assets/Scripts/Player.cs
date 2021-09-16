using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody;
    public float acceleration = 1.0f;
    public float angularVelocity = 180.0f;
    public float maxVelocity = 10.0f;

    public Rigidbody2D prefabBullet;
    public float bulletVelocity = 10.0f;
    public float bulletMaxSeconds = 20.0f;

    private float countSeconds = 0.0f;
    private GameObject[] bulletsSpawns;

    public AudioSource playerAudioSource;
    public AudioClip deathAudioClip;
    public AudioClip shootAudioClip;

    void Start()
    {
    }
    private void Update()
    {
        /*Shoot*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            /*Set Position*/
            Rigidbody2D bullet = Instantiate(prefabBullet, playerRigidbody.position, Quaternion.Euler(0.0f, 0.0f, playerRigidbody.rotation));

            /*Set velocity*/
            bullet.velocity = transform.up * bulletVelocity;

            /*Play sound when shoot*/
            playerAudioSource.PlayOneShot(shootAudioClip);
        }

        /*Destroy bullets after x seconds*/
        countSeconds += Time.deltaTime;
        if (countSeconds > bulletMaxSeconds)
        {
            bulletsSpawns = GameObject.FindGameObjectsWithTag("bullets");
            foreach (GameObject bullets in bulletsSpawns)
            {
                Destroy(bullets);
            }
            countSeconds = 0;
        }
    }
    /*Use fixed update when need to modify object (recommended to physics)*/
    void FixedUpdate()
    {
        /*Movements*/
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 direction = transform.up * acceleration;
            playerRigidbody.AddForce(direction, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.rotation += angularVelocity * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 direction = transform.up * (acceleration - (acceleration * 2));
            playerRigidbody.AddForce(direction, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.rotation -= angularVelocity * Time.deltaTime;
        }

        /*Set Max Velocity*/
        if (playerRigidbody.velocity.magnitude > maxVelocity)
        {
            playerRigidbody.velocity = Vector2.ClampMagnitude(playerRigidbody.velocity, maxVelocity);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Play sound when die*/
        playerAudioSource.PlayOneShot(deathAudioClip);
        float audioDelay = deathAudioClip.length;

        /*Destroy Player*/
        Destroy(gameObject, audioDelay);
    }
}
