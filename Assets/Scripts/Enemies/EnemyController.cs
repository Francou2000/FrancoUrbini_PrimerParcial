using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemyData;
    private Enemy enemyDataInstance;

    private Animator animator;
    private Transform enemyTransform;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyTransform = transform;

        enemyDataInstance = Instantiate(enemyData);

        StartCoroutine(EnemyBehaviour());
    }

    private IEnumerator EnemyBehaviour()
    {
        while (true)
        {
            enemyDataInstance.DetectPlayer(enemyTransform);

            if (enemyDataInstance.isAttackRange && enemyDataInstance.attackTimer <= 0f)
            {
                enemyDataInstance.Attack(enemyTransform, animator);
            }

            if (enemyDataInstance.health <= 0f)
            {
                enemyDataInstance.Death(enemyTransform, animator);
            }

            enemyDataInstance.Walk(enemyTransform, animator);
            enemyDataInstance.attackTimer -= Time.deltaTime;
            yield return null;
        }
    }
}
