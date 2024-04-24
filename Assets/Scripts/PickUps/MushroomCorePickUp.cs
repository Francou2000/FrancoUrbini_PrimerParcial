using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[3]++;
    }
}
