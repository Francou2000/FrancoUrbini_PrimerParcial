using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemyFactory enemyFactory;

    public string enemyTypeToSpawn; 

    private float timer = 25;
    private float time;

    void Start()
    {
        time = 0;
        enemyFactory = new EnemyTypeFactory(); 
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timer)
        {
            InstantiateEnemy();
            time = 0;
        }
    }

    void InstantiateEnemy()
    {
        CommonEnemy enemy = enemyFactory.CreateEnemy(enemyTypeToSpawn);
        Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
    }
}
