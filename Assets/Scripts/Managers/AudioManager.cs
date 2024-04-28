using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip getHit;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject player;

    private void Start()
    {
        var playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.onPlayerHit += PlayHitSound;
        }
    }

    public void PlayHitSound()
    {
        player.GetComponent<AudioSource>().PlayOneShot(getHit);
    }
}
