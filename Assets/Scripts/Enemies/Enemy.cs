using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemies/Common")]
public class Enemy : ScriptableObject
{
    public float maxHealth;
    public GameObject dropCore;
    public GameObject dropPotion; 

    public float moveSpeed;
    public float playerDistance;

    public float attackCooldown;
}
