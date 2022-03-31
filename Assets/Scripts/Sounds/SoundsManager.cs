using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioClip coins, destroy, hurt, playerJump, playerShoot, enemyBang, reachFlag;
    public AudioSource adisrc;
    public AudioSource backgroundSound;

    // Start is called before the first frame update
    void Start()
    {
        coins = Resources.Load<AudioClip>("Coin");
        destroy = Resources.Load<AudioClip>("Death");
        hurt = Resources.Load<AudioClip>("Hurt");
        playerJump = Resources.Load<AudioClip>("playerJump");
        playerShoot = Resources.Load<AudioClip>("playerShoot");
        enemyBang = Resources.Load<AudioClip>("enemyBang");
        reachFlag = Resources.Load<AudioClip>("success");

        adisrc = GetComponent<AudioSource>();
        backgroundSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Coin":
                adisrc.clip = coins;
                adisrc.PlayOneShot(coins, 0.6f);
                break;
            case "Death":
                adisrc.clip = destroy;
                adisrc.PlayOneShot(destroy, 1f);
                break;
            case "Hurt":
                adisrc.clip = hurt;
                adisrc.PlayOneShot(hurt, 1f);
                break;
            case "PlayerJump":
                adisrc.clip = playerJump;
                adisrc.volume = 0.12f;
                adisrc.PlayOneShot(playerJump, 1f);
                break;
            case "PlayerShoot":
                adisrc.clip = playerShoot;
                adisrc.PlayOneShot(playerShoot, 1f);
                break;
            case "EnemyBang":
                adisrc.clip = playerShoot;
                adisrc.PlayOneShot(playerShoot, 1f);
                break;
            case "success":
                adisrc.clip = reachFlag;
                adisrc.PlayOneShot(reachFlag, 1f);
                break;
        }
    }

    public void test()
    {
        backgroundSound.mute = true;
    }
}
