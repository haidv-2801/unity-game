using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth;
    public float MaxHealth;

    public void IncreBlood(int numberOfBlood)
    {
        if(CurrentHealth + numberOfBlood > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += numberOfBlood;
        }
    }

}
