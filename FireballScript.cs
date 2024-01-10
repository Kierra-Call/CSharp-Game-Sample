using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    public float sphereLifetime = 5f; // Set the maximum lifetime of the sphere

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, sphereLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Triggered!");
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the sphere
        }
    }
}
