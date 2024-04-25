using System.Collections;
using UnityEngine;

public class TurtleEnemy : CommonEnemy
{
    private Animator animator;

    public Enemy enemyData;

    private float moveSpeed;

    Vector3 stopPosition;

    private float walkTime;
    public float walkCounter;
    private float waitTime;
    public float waitCounter;

    private int WalkDirection;

    [SerializeField] private bool isWalking;

    public Transform playerCheck;
    public LayerMask playerMask;

    public bool isRunning;
    public bool isAttackRange;

    public Transform player;

    public float health;

    private float timer = 0f;

    private int drop;

    void Start()
    {
        animator = GetComponent<Animator>();

        walkTime = Random.Range(7, 10);
        waitTime = Random.Range(3, 5);

        waitCounter = waitTime;
        walkCounter = walkTime;

        moveSpeed = enemyData.moveSpeed;
        health = enemyData.maxHealth;

        ChooseDirection();
    }

    void Update()
    {
        DetectPlayer();
        Walk();

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

    public override void DetectPlayer()
    {
        isRunning = Physics.CheckSphere(playerCheck.position, enemyData.playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(playerCheck.position, enemyData.playerDistance / 2, playerMask);

        if (isRunning)
        {
            isWalking = false;

            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);

            Collider[] colliders = Physics.OverlapSphere(playerCheck.position, enemyData.playerDistance, playerMask);

            transform.LookAt(colliders[0].gameObject.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, colliders[0].gameObject.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (walkTime > 0f)
            {
                isWalking = true;
            }
        }
    }

    public override void Walk()
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);

            moveSpeed = enemyData.moveSpeed;

            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 1:
                    transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 2:
                    transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 3:
                    transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }

            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;

                moveSpeed = 0f;

                transform.position = stopPosition;
                animator.SetBool("isWalking", false);
            }
        }
        if (!isWalking && !isRunning)
        {
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
            }
            else
            {
                ChooseDirection();
            }
        }
    }

    public override void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);

        walkCounter = walkTime;
        waitCounter = waitTime;

        isWalking = true;
    }

    public override void Death()
    {
        ChooseDrop();

        animator.SetTrigger("Dead");

        StartCoroutine(DeathRoutine());
    }

    public override void ChooseDrop()
    {
        drop = Random.Range(0, 9);
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
