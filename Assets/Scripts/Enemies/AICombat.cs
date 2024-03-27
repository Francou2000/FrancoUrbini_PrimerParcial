using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour
{
    public float health = 1f;

    private int drop;

    public GameObject dropCore;
    public GameObject dropPotion;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
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

        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait for the death animation to finish playing
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Instantiate drop if necessary
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

        // Destroy the GameObject
        Destroy(gameObject);
    }
}