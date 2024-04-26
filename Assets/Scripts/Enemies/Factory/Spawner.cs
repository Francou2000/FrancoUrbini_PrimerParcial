using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;

    private float timer = 25f;
    public float time;

    void Start()
    {
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timer)
        {
            SpawnEnemy();
            time = 0;
        }
    }

    public void SpawnEnemy()
    {
        CommonEnemy enemy = enemyFactory.CreateEnemy();
        Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
    }
}
