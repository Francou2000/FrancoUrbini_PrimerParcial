using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animator animator;

    public float damage = 1f;

    private float timer; 
    private float cooldownTime; 

    void Start()
    {
        animator = GetComponent<Animator>();
        timer = 1.0f; 
        cooldownTime = 0.0f;
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        cooldownTime += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.Mouse0) && cooldownTime >= timer)
        {
            animator.SetBool("isAttacking", true);
            GetComponent<BoxCollider>().enabled = true;
            cooldownTime = 0.0f; 
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (cooldownTime > timer) 
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyBase>() != null)
        {
            other.gameObject.GetComponent<EnemyBase>().TakeDamage(damage);
        }
    }
}
