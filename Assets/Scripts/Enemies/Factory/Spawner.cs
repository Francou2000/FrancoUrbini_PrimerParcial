using UnityEngine;

public class Spawner : MonoBehaviour
{
    private EnemyFactory enemyFactory;

    public enemies enemiesValue;

    private float timer = 25f;
    public float time;

    void Start()
    {
        time = 0;

        switch (enemiesValue)
        { 
            case enemies.slime:
                enemyFactory = new SlimeFactory();
                break;
            case enemies.mushroom:
                enemyFactory = new MushroomFactory();
                break;
            case enemies.turtle:
                enemyFactory = new TurtleFactory();
                break;
            case enemies.cactus:
                enemyFactory = new CactusFactory();
                break;
            default:
                break;
        }
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
        if (enemyFactory != null)
        {
            CommonEnemy enemy = enemyFactory.CreateEnemy();
            Instantiate(enemy.gameObject, transform.position, Quaternion.identity);
        }
    }
}

public enum enemies
{
    slime,
    cactus,
    turtle,
    mushroom
}