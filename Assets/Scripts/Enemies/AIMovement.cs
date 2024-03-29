using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class AIMovement : MonoBehaviour
{
    private Animator animator;

    public float moveSpeed = 1f;

    Vector3 stopPosition;

    private float walkTime;
    public float walkCounter;
    private float waitTime;
    public float waitCounter;

    private int WalkDirection;

    [SerializeField] private bool isWalking;

    public Transform playerCheck;
    public float playerDistance = 3f;
    public LayerMask playerMask;

    public bool isRunning;
    public bool isAttackRange;

    public Transform player;

    void Start()
    {
        animator = GetComponent<Animator>();

        walkTime = Random.Range(7, 10);
        waitTime = Random.Range(3, 5);

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void Update()
    {
        DetectPlayer();
        Walk();
    }

    public void DetectPlayer()
    {
        isRunning = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);
        isAttackRange = Physics.CheckSphere(playerCheck.position, playerDistance/2, playerMask);

        if (isRunning)
        {
            isWalking = false;

            moveSpeed = 1.5f;

            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);

            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            if (walkTime > 0f)
            {
                isWalking = true;
            }
        }
    }

    public void Walk() 
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);

            moveSpeed = 1f;
            
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

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);

        walkCounter = walkTime;
        waitCounter = waitTime;

        isWalking = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDistance);
    }
}
