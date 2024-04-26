using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyFactory enemyFactory;

    private EventQueue eventQueue;

    private float timer = 25f;
    public float time;

    void Start()
    {
        time = 0;

        eventQueue = new EventQueue();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time > timer)
        {
            ICommand command = new SpawnCommand(this);
            eventQueue.QueueCommand(command);
        }
    }

    public void SpawnEnemy()
    {
        CommonEnemy enemy = enemyFactory.CreateEnemy();
        Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
        time = 0;
    }
}
