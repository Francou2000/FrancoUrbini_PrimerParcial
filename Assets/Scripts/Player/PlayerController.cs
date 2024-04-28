using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action onPlayerHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            onPlayerHit?.Invoke();
        }
    }
}
