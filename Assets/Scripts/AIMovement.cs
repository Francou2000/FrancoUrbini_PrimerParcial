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

    [SerializeField] private bool isRunning;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //So that all the prefabs don't move/stop at the same time
        walkTime = Random.Range(7, 10);
        waitTime = Random.Range(3, 5);


        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        Walk();
    }

    public void DetectPlayer()
    {
        isRunning = Physics.CheckSphere(playerCheck.position, playerDistance, playerMask);

        if (isRunning)
        {
            isWalking = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);

            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            isWalking = true;
        }
    }


    public void Walk() 
    {
        if (isWalking)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", true);
            
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
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isWalking", false);
                //reset the waitCounter
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);

        isWalking = true;
        walkCounter = walkTime;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDistance);
    }
}
