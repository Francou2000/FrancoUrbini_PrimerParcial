
public class MushroomFactory : EnemyFactory
{
    public override CommonEnemy CreateEnemy()
    {
        return new MushroomEnemy();
    }
}
