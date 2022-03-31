using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    public int numberOfBlood;
    PlayerHealth playerHealth;

    
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.IncreBlood(numberOfBlood);
            Destroy(gameObject);
        }
    }

}
