using UnityEngine;

[CreateAssetMenu(fileName = "MushroomFactory", menuName = "Enemies/Factory/Mushroom Factory")]
public class MushroomFactory : EnemyFactory
{
    [SerializeField] private MushroomEnemy mushroomPrefab;

    public override CommonEnemy CreateEnemy()
    {
        return Instantiate(mushroomPrefab);
    }
}
