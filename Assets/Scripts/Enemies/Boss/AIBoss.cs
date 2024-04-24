using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoss : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 1f;
    public float health = 1f;

    public Transform playerCheck;
    public float playerDistance = 3f;
    public LayerMask playerMask;

    public bool isRunning = false;
    public bool isAttackRange = false;

    public Transform player;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        DetectPlayer();

        if (isAttackRange == true)
        {
            StartCoroutine(AttackRoutine());
        }

        if (health <= 0f)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    public void DetectPlayer()
    {
        isRunning = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(playerCheck.position, playerDistance / 2, playerMask);

        if (isRunning == true)
        {
            animator.SetBool("isRunning", true);

            moveSpeed = 1;

            player = GameObject.FindGameObjectWithTag("Player").transform;

            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (isRunning == false)
        {
            animator.SetBool("isRunning", false);

            moveSpeed = 0;
        }  
    }

    private IEnumerator DeathRoutine()
    {
        animator.SetTrigger("Dead");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        Destroy(this.gameObject);
    }

    private IEnumerator AttackRoutine()
    {
        animator.SetTrigger("Attack1");

        gameObject.GetComponent<BoxCollider>().enabled = true;

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        animator.SetTrigger("Attack2");

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDistance);
    }
}
