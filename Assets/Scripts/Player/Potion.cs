using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healthRecovered = 25;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Inventory.Instance.potions >= 1)
        {
            UsePotion();
        }
    }

    void UsePotion()
    {
        Inventory.Instance.potions -= 1;
        PlayerState.Instance.currentHealth += healthRecovered;

        if (PlayerState.Instance.currentHealth >= 100) 
        {
            PlayerState.Instance.currentHealth = 100;
        }
    }
}
