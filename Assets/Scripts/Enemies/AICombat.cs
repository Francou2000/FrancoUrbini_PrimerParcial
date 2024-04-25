using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    public Enemy enemyData;

    public float health;

    private float timer = 0f;

    private int drop;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        health = enemyData.maxHealth;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (this.gameObject.GetComponent<AIMovement>().isAttackRange == true && timer <= 0f)
        {
            StartCoroutine(AttackRoutine());
            timer = enemyData.attackCooldown;
        }

        if (health <= 0f)
        {
            Death();
        }
    }

    private void ChooseDrop()
    {
        drop = Random.Range(0, 9);
    }

    private void Death()
    {
        ChooseDrop();

        animator.SetTrigger("Dead");

        StartCoroutine(DeathRoutine());
    }

    private IEnumerator DeathRoutine()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        switch (drop)
        {
            case 0:
            case 1:
            case 2:
                Instantiate(enemyData.dropCore, transform.position, Quaternion.identity);
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                Instantiate(enemyData.dropPotion, transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }

    private IEnumerator AttackRoutine()
    {
        animator.SetTrigger("Attack");

        gameObject.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}