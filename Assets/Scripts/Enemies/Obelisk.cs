using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public ObeliskCorner[] obeliskCorners = new ObeliskCorner[4];

    private bool canSpawnBoss = true;
    public GameObject bossSpawnPoints;
    public GameObject boss;

    public void Update()
    {
        Activate();
    }

    public void Activate()
    {
        if (obeliskCorners[0].isOn && obeliskCorners[1].isOn && obeliskCorners[2].isOn && obeliskCorners[3].isOn && canSpawnBoss)
        {
            Instantiate(boss, bossSpawnPoints.transform.position, Quaternion.identity);
            Deactivate();
        }
    }

    private void Deactivate()
    {
        canSpawnBoss = false;
    }
}

