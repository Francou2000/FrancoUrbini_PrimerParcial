using UnityEngine;

public class Obelisk : MonoBehaviour
{
    public ObeliskCorner[] obeliskCorners = new ObeliskCorner[4];

    private bool canSpawnBoss = true;
    public GameObject bossSpawnPoints;

    public Enemy enemyType;

    public void Update()
    {
        if (canSpawnBoss)
        {
            if (obeliskCorners[0].isOn && obeliskCorners[1].isOn && obeliskCorners[2].isOn && obeliskCorners[3].isOn)
            {
                Activate();
            }
        }
    }

    public void Activate()
    {
        if (enemyType != null)
        {
            GameObject enemyPrefab = enemyType.prefab; 
            if (enemyPrefab != null)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                Deactivate();
            }
        }
    }

    private void Deactivate()
    {
        canSpawnBoss = false;
    }
}

