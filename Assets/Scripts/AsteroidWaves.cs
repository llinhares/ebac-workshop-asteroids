using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidWaves : MonoBehaviour
{
    public Asteroid prefabAsteroid;
    public int asteroidsQuantity = 3;
    // Start is called before the first frame update
    void Start()
    {
        /* Spawn Asteroids */
        for(int i = 0; i < asteroidsQuantity; i++)
        {
            float x = Random.Range(-8.0f, 8.0f);
            float y = Random.Range(-5.0f, 5.0f);
            Vector3 spawnPosition = new Vector3(x, y, 0.0f);
            Instantiate(prefabAsteroid, spawnPosition, Quaternion.identity);
        }
    }
}
