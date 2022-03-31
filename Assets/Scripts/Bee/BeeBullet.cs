using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : MonoBehaviour
{
    
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag != "Enemies")
        {
            Destroy(gameObject);
        }
    }
}
