using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{

    [SerializeField] private GameObject bulletWeapon1;
    [SerializeField] private GameObject bulletWeapon2;
    
    
    private PlayerShoot playerShoot;
    private SpriteRenderer sr;

    private void Awake()
    {
        playerShoot = FindObjectOfType<PlayerShoot>();

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(2);
        }
    }

    void SetWeapon(int weaponID)
    {
        switch (weaponID)
        {
            case 1:
                playerShoot.SetBulletPrefabs(bulletWeapon1);
                ChangPlayerColor(Color.blue);
                break;

            case 2:
                playerShoot.SetBulletPrefabs(bulletWeapon2);
                ChangPlayerColor(Color.magenta);
                break;

        }
    }

    void ChangPlayerColor(Color c)
    {
        sr.color = c;
    }
}
