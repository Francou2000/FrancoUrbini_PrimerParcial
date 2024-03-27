using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyToSpawn;

    private float timer = 25;
    private float time;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timer)
        {
           Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            time = 0;   
        }
    }
}
