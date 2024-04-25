using System.Collections;
using UnityEngine;

public class BossEnemy : EnemyBase
{
    private Animator animator;

    public GameObject gameManager;

    public float moveSpeed = 1f;
    public float health = 1f;

    public Transform playerCheck;
    public float playerDistance = 3f;
    public LayerMask playerMask;

    public float attackCooldown = 3f;
    private float timer = 0f;

    public bool isRunning = false;
    public bool isAttackRange = false;

    public Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        DetectPlayer();

        timer -= Time.deltaTime;

        if (isAttackRange == true && timer <= 0f)
        {
            Attack();
            timer = attackCooldown;
        }

        if (health <= 0f)
        {
            Death();
        }
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
        isRunning = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(playerCheck.position, playerDistance / 1.25f, playerMask);


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
