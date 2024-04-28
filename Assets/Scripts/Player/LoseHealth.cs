using System.Collections;
using UnityEngine;

public class LoseHealth : MonoBehaviour
{
    public float damageReceived = 10;

    [SerializeField] private float invincibleFrames= 2.5f;
    [SerializeField] private GameObject player;

    IHealthCanvas healthCanvas;

    public void Start()
    {
        healthCanvas = CanvasController.Instance;

        var playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.onPlayerHit += GetHit;
        }
    }

    public void GetHit()
    {
        StartCoroutine(LoseHealthRoutine());
    }

    private IEnumerator LoseHealthRoutine()
    {
        healthCanvas.HealthBar.currentHealth -= damageReceived;

        gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(invincibleFrames);

        gameObject.GetComponent<CapsuleCollider>().enabled = true;
    }
}
