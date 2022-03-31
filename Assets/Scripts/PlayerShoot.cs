using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    //bullet
    [SerializeField]
    GameObject bulletRef;

    private bool isShooting = false;

    [SerializeField]
    public Transform bulletRespawnPos;

    [SerializeField]
    private float shootDelay = .5f;

    public SoundsManager sound;

    public Animator playerAnimation;

    PlayerController playerController;

    void Start()
    {
        playerAnimation = GetComponent<Animator>();

        playerController = FindObjectOfType<PlayerController>();
     
        //set sound
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundsManager>();
    }

 
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (isShooting) return; // dont shoot again while shooting
            sound.PlaySound("PlayerShoot");
            playerAnimation.Play("PlayerShoot");
            isShooting = true;
            GameObject buller = Instantiate(bulletRef);
            Debug.Log(playerController.isFacingLeft);
            buller.GetComponent<BulletScript>().StartShoot(playerController.isFacingLeft);
            buller.transform.position = bulletRespawnPos.transform.position;

            //thuc hien hanh dong sau 1 thoi gian nhat dinh
            Invoke("ResetShoot", shootDelay);
        }
    }

    void ResetShoot()
    {
        isShooting = false;
        playerAnimation.Play("PlayerIdle");
    }

    public void SetBulletPrefabs(GameObject prefab)
    {
        bulletRef = prefab;
    }
}
