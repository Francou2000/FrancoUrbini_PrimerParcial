using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[0]++;
    }
}
