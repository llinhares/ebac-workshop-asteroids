using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleAsteroids : MonoBehaviour
{
    public Rigidbody2D littleAsteroidRigidBody;
    public float maxVelocity = 1.0f;

    public AudioSource explosionAudioSource;
    public AudioClip explosionAudioClip;

    void Start()
    {

        Vector2 direction = Random.insideUnitCircle;
        direction *= maxVelocity;
        littleAsteroidRigidBody.velocity = direction;
    }
        private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Play sound when explode*/
        explosionAudioSource.PlayOneShot(explosionAudioClip);
        float audioDelay = explosionAudioClip.length;

        /*Destroy Asteroid*/
        Destroy(gameObject, audioDelay);
        Destroy(collision.gameObject);
    }
}
