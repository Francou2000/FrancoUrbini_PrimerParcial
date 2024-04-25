using System.Collections;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    public float damageReceived = 10;

    [SerializeField] private float invincibleFrames= 2.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(LoseHealthRoutine());
        }
    }

    private IEnumerator LoseHealthRoutine()
    {
        PlayerState.Instance.currentHealth -= damageReceived;

        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(invincibleFrames);

        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
