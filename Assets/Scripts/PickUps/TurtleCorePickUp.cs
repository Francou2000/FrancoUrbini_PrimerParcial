using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleCorePickUp : IPickUp
{
    public void PickUp()
    {
        Inventory.Instance.coreItems[2]++;
    }

}
