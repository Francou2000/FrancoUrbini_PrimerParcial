using UnityEngine;

[CreateAssetMenu(fileName = "CactusFactory", menuName = "Enemies/Factory/Cactus Factory")]
public class CactusFactory : EnemyFactory
{
    [SerializeField] private CactusEnemy cactusPrefab;

    public override CommonEnemy CreateEnemy()
    {
        return Instantiate(cactusPrefab);
    }
}
