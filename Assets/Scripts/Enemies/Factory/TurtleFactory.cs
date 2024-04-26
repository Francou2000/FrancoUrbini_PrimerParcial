using UnityEngine;

[CreateAssetMenu(fileName = "TurtleFactory", menuName = "Enemies/Factory/Turtle Factory")]
public class TurtleFactory : EnemyFactory
{
    [SerializeField] private TurtleEnemy turtlePrefab;

    public override CommonEnemy CreateEnemy()
    {
        return Instantiate(turtlePrefab);
    }
}
