using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeShooter : MonoBehaviour
{
    [SerializeField] // possible to access outside
    private GameObject bullet;

    void start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 7));
        Instantiate(bullet, transform.position, Quaternion.identity); // determine enemies bullet's position
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
