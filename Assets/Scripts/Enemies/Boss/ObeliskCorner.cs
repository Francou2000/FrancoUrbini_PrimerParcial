using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeliskCorner : MonoBehaviour
{
    public bool isOn = false;

    public coreItems coreItems;

    public void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && Inventory.Instance.coreItems[(int)coreItems] == 3)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            isOn = true;
        }
    }
}

public enum coreItems
{
    slimeCore,
    cactusCore,
    turtleCore,
    mushroomCore,
    potion
}