using UnityEngine;

[CreateAssetMenu(fileName = "SlimeFactory", menuName = "Enemies/Factory/Slime Factory")]
public class SlimeFactory : EnemyFactory
{
    [SerializeField] private SlimeEnemy slimePrefab;

    public override CommonEnemy CreateEnemy()
    {
        return Instantiate(slimePrefab);
    }
}
