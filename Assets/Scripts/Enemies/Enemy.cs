using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyType", menuName = "Enemies/Common")]
public class Enemy : ScriptableObject
{
    public float health = 1f;
    public GameObject dropCore;
    public GameObject dropPotion; 

    public float moveSpeed = 1f;
    public float playerDistance = 6f;
    public LayerMask playerMask;

    public float attackCooldown = 1f;
    public float attackTimer = 0f;  

    private bool isRunning = false;
    public bool isAttackRange = false;
    private bool isWalking;

    private float walkTime;
    private float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;
    private Vector3 stopPosition;

    public void Attack(Transform enemyTransform, Animator animator)
    {
        if (attackTimer <= 0f)
        {
            animator.SetTrigger("Attack");
            enemyTransform.GetComponent<BoxCollider>().enabled = true;
            attackTimer = attackCooldown;
        }
    }

    public void Death(Transform enemyTransform, Animator animator)
    {
        animator.SetTrigger("Dead");
        ChooseDrop(enemyTransform.position);
        enemyTransform.GetComponent<BoxCollider>().enabled = false;
        Destroy(enemyTransform.gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }

    void ChooseDrop(Vector3 position)
    {
        int drop = Random.Range(0, 9);

        switch (drop)
        {
            case 0:
            case 1:
            case 2:
                Instantiate(dropCore, position, Quaternion.identity);
                break;
            case 3:
            case 4:
            case 5:
            case 6:
                Instantiate(dropPotion, position, Quaternion.identity);
                break;
            default:
                break;
        }
    }

    public void DetectPlayer(Transform enemyTransform)
    {
        isRunning = Physics.CheckSphere(enemyTransform.position, playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(enemyTransform.position, playerDistance / 2, playerMask);
    }

    public void Walk(Transform enemyTransform, Animator animator)
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);

            enemyTransform.position += enemyTransform.forward * moveSpeed * Time.deltaTime;

            walkCounter -= Time.deltaTime;

            if (walkCounter <= 0)
            {
                StopWalking(enemyTransform, animator);
            }
        }
        else
        {
            if (waitCounter > 0)
            {
                waitCounter -= Time.deltaTime;
            }
            else
            {
                ChooseDirection();
                isWalking = true;
            }
        }
    }

    void StopWalking(Transform enemyTransform, Animator animator)
    {
        stopPosition = new Vector3(enemyTransform.position.x, enemyTransform.position.y, enemyTransform.position.z);
        isWalking = false;
        enemyTransform.position = stopPosition;
        animator.SetBool("isWalking", false);
        waitCounter = waitTime;
    }

    void ChooseDirection() 
    {
        walkDirection = Random.Range(0, 4);
        walkCounter = walkTime;
        waitCounter = waitTime;
    }
}
