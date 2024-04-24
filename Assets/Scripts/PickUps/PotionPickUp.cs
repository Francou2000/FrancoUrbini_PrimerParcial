using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.potions++;
    }
}
