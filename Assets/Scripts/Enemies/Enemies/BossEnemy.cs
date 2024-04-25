using System.Collections;
using UnityEngine;

public class BossEnemy : EnemyBase
{
    private Animator animator;

    public GameObject gameManager;

    public Enemy enemyData;

    private float moveSpeed;
    private float health = 1f;

    public Transform playerCheck;
    public LayerMask playerMask;

    private float timer = 0f;

    public bool isRunning = false;
    public bool isAttackRange = false;

    public Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();

        moveSpeed = enemyData.moveSpeed;
        health = enemyData.maxHealth;
    }

    void Update()
    {
        DetectPlayer();

        timer -= Time.deltaTime;

        if (isAttackRange == true && timer <= 0f)
        {
            Attack();
            timer = enemyData.attackCooldown;
        }

        if (health <= 0f)
        {
            Death();
        }
    }

    public override void TakeDamage(float damage)
    {
        health -= damage;
    }

    public override void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    public override void Death()
    {
        StartCoroutine(DeathRoutine());
    }

    public override void DetectPlayer()
    {
        isRunning = Physics.CheckSphere(playerCheck.position, enemyData.playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(playerCheck.position, enemyData.playerDistance / 2f, playerMask);


        if (isRunning == true)
        {
            animator.SetBool("isRunning", true);

            Collider[] colliders = Physics.OverlapSphere(playerCheck.position, enemyData.playerDistance, playerMask);

            transform.LookAt(colliders[0].gameObject.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, colliders[0].gameObject.transform.position, moveSpeed * Time.deltaTime);
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

        GameManager.Instance.Win();
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
}
