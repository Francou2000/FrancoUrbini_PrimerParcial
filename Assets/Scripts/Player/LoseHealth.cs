using System.Collections;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    public float damageReceived = 10;

    [SerializeField] private float invincibleFrames= 2.5f;

    IHealthCanvas healthCanvas;

    public void Start()
    {
        healthCanvas = CanvasController.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(LoseHealthRoutine());
        }
    }

    private IEnumerator LoseHealthRoutine()
    {
        healthCanvas.HealthBar.currentHealth -= damageReceived;

        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(invincibleFrames);

        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
