using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody2D asteroidRigidBody;
    public float maxVelocity = 1.0f;

    public AudioSource explosionAudioSource;
    public AudioClip explosionAudioClip;

    public int litteAsteroidMinQuantity = 2;
    public int litteAsteroidMaxQuantity = 4;
    public LittleAsteroids prefabLittleAsteroids;
    private int quantity;



    void Start()
    {
        Vector2 direction = Random.insideUnitCircle;
        direction *= maxVelocity;
        asteroidRigidBody.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Play sound when explode*/
        explosionAudioSource.PlayOneShot(explosionAudioClip);
        float audioDelay = explosionAudioClip.length;

        /*Destroy Asteroid*/
        Destroy(gameObject, audioDelay);
        Destroy(collision.gameObject);

        /*Spawn little asteroids when big is destroyed*/
        quantity = Random.Range(litteAsteroidMinQuantity, litteAsteroidMaxQuantity);
        for (int i = 0; i < quantity; i++)
        {
            Vector3 spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            Instantiate(prefabLittleAsteroids, spawnPosition, Quaternion.identity);
        }
    }
}
