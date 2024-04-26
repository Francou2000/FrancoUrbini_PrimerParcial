
public class TurtleFactory : EnemyFactory
{
    public override CommonEnemy CreateEnemy()
    {
        return new TurtleEnemy();
    }
}
