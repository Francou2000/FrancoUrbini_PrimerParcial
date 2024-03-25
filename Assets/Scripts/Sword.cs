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
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("isAttacking", true);
            GetComponentInParent<BoxCollider>().enabled = true;
            time = 0;           
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (time > timer)
        {
            GetComponentInParent<BoxCollider>().enabled = false;
        }
    }
}
