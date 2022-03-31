using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed, range;
    private float distToPlayer;
    [HideInInspector]
    public bool mustPatrol;
    public Rigidbody2D rb;
    private bool mustTurn;
    public Transform groundCheckpos;
    public LayerMask groundLayer;

    public Collider2D bodyCollider;
    public GameObject player;

    //enemy
    EnemyScript enemy;
    void Start()
    {
        mustPatrol = true;

        //player
        player = GameObject.FindWithTag("Player");

        //enemy
        enemy = FindObjectOfType<EnemyScript>();
    }

    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
    }
    void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckpos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    //Hàm lật Nhân vật
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

   /* void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            //bleed
            int bulletDamage = other.GetComponent<BulletScript>().damage;
            enemy.Bleed(bulletDamage);

            bool dead = enemy.isDead();
            if (dead)
            {
                //
                anim.SetTrigger("isDead");
                sound.PlaySound("EnemyBang");
                rb.velocity = Vector2.zero;
                Destroy(other.gameObject);
                Invoke("waitForDes", 0.5f);
            }
          
        }
    }

    void waitForDes()
    {
        Destroy(gameObject);
    }*/

    void Shoot()
    {

    }
}
