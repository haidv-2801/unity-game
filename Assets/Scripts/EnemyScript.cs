using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;

    private bool BulletHit;
    private float timeToColor;

    //change anim state
   
    Animator anim;

    //sound control
    SoundsManager sound;

    //sprite
    SpriteRenderer sp;

    public Rigidbody2D rb;

    void Start()
    {
        timeToColor = 0.2f;
        BulletHit = false;

        //animator
        anim = GetComponent<Animator>();

        //set sound
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundsManager>();

        sp = GetComponent<SpriteRenderer>();
    }


    public void Bleed(int bulletDamage)
    {
        if(CurrentHealth - bulletDamage > 0) // enemy still alive
        {
            CurrentHealth = CurrentHealth - bulletDamage;
        }
        else
        {
            CurrentHealth = 0;
        }
    }

    public bool isDead()
    {
        return CurrentHealth == 0;
    }


   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.gameObject.tag == "Bullet")
       {
            //bullet hit , change color
            if (!BulletHit)
            {
                BulletHit = true;
                StartCoroutine("SwitchColor");
            }


            //destroy bullet and increasing player coin
            Destroy(other.gameObject);
            FindObjectOfType<LevelManager>().AddCoins(3);

           //bleed
           int bulletDamage = other.GetComponent<BulletScript>().damage;
           Bleed(bulletDamage);


           bool dead = isDead();
           if (dead)
           {
               //
               anim.SetTrigger("isDead");
               sound.PlaySound("EnemyBang");
               /*rb.velocity = Vector2.zero;*/
               Destroy(other.gameObject);
               Invoke("waitForDes", 0.5f);
           }

       }
   }

    IEnumerator SwitchColor()
    {
        sp.color = Color.yellow;
        yield return new WaitForSeconds(timeToColor);
        sp.color = Color.white;
        BulletHit = false;
    }

    void waitForDes()
   {
       Destroy(gameObject);
   }

}
