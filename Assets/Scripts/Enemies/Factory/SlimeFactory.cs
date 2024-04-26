
public class SlimeFactory : EnemyFactory
{
    public override CommonEnemy CreateEnemy()
    {
        return new SlimeEnemy();
    }
}
