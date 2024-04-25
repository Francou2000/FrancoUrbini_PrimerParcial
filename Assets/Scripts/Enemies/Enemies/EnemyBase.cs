using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public abstract void Attack();

    public abstract void DetectPlayer();

    public abstract void Death();

    public abstract void TakeDamage(float damage);
}
