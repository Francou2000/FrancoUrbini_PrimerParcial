using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;

    private float timer;
    private float time;

    void Start()
    {
        animator = GetComponent<Animator>();

        time = 0;
        timer = 1;
    }


    void Update()
    {
        Attack();
    }

    void Attack()
    {
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
            GetComponent<BoxCollider>().enabled = true;
            time = 0;
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (time > timer)
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<AICombat>().health -= 1;
        }
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<AIBoss>().health -= 1;
        }
    }
}
