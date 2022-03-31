using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    float speed;

    public int damage;
    
    [SerializeField]
    float timeToDestroy;

    private Animator bulletAnim;

    void Start()
    {      
        bulletAnim = GetComponent<Animator>();
        bulletAnim.Play("BulletDestroy");
        Invoke("DestroyBullet", .6f);
    }

    public void StartShoot(bool isFacingLeft)
    {
        Rigidbody2D rg2d = GetComponent<Rigidbody2D>();
        if (isFacingLeft)
        {
            rg2d.transform.Rotate(new Vector3(0f, 0f, -180f), Space.Self);
            rg2d.velocity = new Vector2(-speed, 0);
        }
        else
        {
            rg2d.transform.Rotate(new Vector3(0f, 0f, 0f), Space.Self);
            rg2d.velocity = new Vector2(speed, 0);
        }

        Destroy(gameObject, timeToDestroy);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            UnityEngine.Debug.Log("bullet reaching ground");         
            DestroyBullet();
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
