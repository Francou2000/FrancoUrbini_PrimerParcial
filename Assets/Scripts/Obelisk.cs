using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public ObeliskCorner[] obeliskCorners = new ObeliskCorner[4];

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Activate();
        }
    }

    public void Activate()
    {
        if (obeliskCorners[0].isOn && obeliskCorners[1].isOn && obeliskCorners[2].isOn && obeliskCorners[3].isOn)
        {
            
        }
    }
}

