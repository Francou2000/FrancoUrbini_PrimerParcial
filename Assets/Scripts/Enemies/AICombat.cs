using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    public float health = 1f;

    public GameObject dropCore;
    public GameObject dropPotion;

    private int drop;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(this.gameObject.GetComponent<AIMovement>().isAttackRange == true)
        {
            StartCoroutine(AttackRoutine());
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
                Instantiate(dropCore, transform.position, Quaternion.identity);
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                Instantiate(dropPotion, transform.position, Quaternion.identity);
                break;
            default:
                break;
        }

        Destroy(this.gameObject);
    }

    private IEnumerator AttackRoutine()
    {
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
    }
}