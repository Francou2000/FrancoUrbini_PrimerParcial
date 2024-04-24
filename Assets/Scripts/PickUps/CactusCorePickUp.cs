using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[1]++;
    }
}
