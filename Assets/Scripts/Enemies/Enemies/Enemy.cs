using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemies/Enemy")]
public class Enemy : ScriptableObject
{
    public float maxHealth;
    public GameObject dropCore;
    public GameObject dropPotion;

    public GameObject prefab;

    public float moveSpeed;
    public float playerDistance;

    public float attackCooldown;

    internal void TakeDamage(float damage)
    {
        throw new NotImplementedException();
    }
}
