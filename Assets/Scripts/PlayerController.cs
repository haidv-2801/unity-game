using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(AudioSource))]

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 7f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isTouchingGround;

    public Animator playerAnimation;

    public Vector3 respawnPoint;
    LevelManager gameLevelManager;

    public SoundsManager sound;

    public AudioSource footstep;
    PlayerHealth playerHealth;

    public bool isFacingLeft;

    PauseGameController pauseGameController;

    void Start()
    {
        //getcomponent : tham chieu cac thanh phan trong 1 object
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
       
        //set respawnpoint
        respawnPoint = transform.position;

        gameLevelManager = FindObjectOfType<LevelManager>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        pauseGameController  = FindObjectOfType<PauseGameController>();

        //set sound
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundsManager>();

        footstep = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        movement = Input.GetAxis("Horizontal"); // nam ngang
        if (movement > 0f) // moving right
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // chi thay doi van toc nam ngang
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);

            //play running sound
            sound.PlaySound("PlayerRun");

            //player facing right
            isFacingLeft = false;
        }
        else if (movement < 0f) // moving left
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y); // chi thay doi van toc nam ngang
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            //play running sound
            sound.PlaySound("PlayerRun");

            //player facing left
            isFacingLeft = true;
        }
        else // stationary ball
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        //player slide
        if (Input.GetMouseButtonDown(1))
        {
            playerAnimation.SetTrigger("isSlide");
        }

        //player jump
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            sound.PlaySound("PlayerJump");
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        playerAnimation.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("onGround", isTouchingGround);

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemies"))
        {
            playerAnimation.Play("PlayerHurt");
            sound.PlaySound("Hurt");
            playerHealth.CurrentHealth -= 2;
            if (playerHealth.CurrentHealth <= 0)
            {
                FindObjectOfType<SoundsManager>().test();
                sound.PlaySound("Death");
                GameOver();
                gameLevelManager.Respawn();
            }
        }
    }

    private void GameOver()
    {
        //sound
        FindObjectOfType<PauseGameController>().ToggleGameoverUI();
    }

    private void GameVictory()
    {
        //sound
        FindObjectOfType<PauseGameController>().ToggleVictoryUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "DeathZone")
        {
            //what will happen when player enters the FallDetector zone 
            playerHealth.CurrentHealth = 0;
            FindObjectOfType<SoundsManager>().test();
            sound.PlaySound("Death");
            GameOver();
            gameLevelManager.Respawn();
        }

        if(other.tag == "water")
        {
            /*playerAnimation.SetBool("isTouchedWater", true);*/
        }

        if (other.tag == "CheckPoint")
        {
            sound.PlaySound("success");
            respawnPoint = other.transform.position;
        }

        if (other.tag == "Coins")
        {
            sound.PlaySound("Coin");
        }

        if (other.tag == "Potion")
        {
            sound.PlaySound("Coin");
        }

        //Cổng qua màn
        if (other.tag == "Gate")
        {
            FindObjectOfType<SoundsManager>().test();
            GameVictory();
        }
    }

    /// <summary>
    /// Âm thanh chạy
    /// </summary>
    private void Footstep()
    {
        footstep.Play();
    }
}
