
public class CactusFactory : EnemyFactory
{
    public override CommonEnemy CreateEnemy()
    {
        return new CactusEnemy();
    }
}
