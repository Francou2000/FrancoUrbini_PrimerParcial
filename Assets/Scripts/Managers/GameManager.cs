using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanelToActivate;
    [SerializeField] private GameObject losePanelToActivate;

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        if(PlayerState.Instance.currentHealth <= 0)
        {
            Lose();
        }
    }

    public void Win()
    {
        TimeController.Instance.isTimeStopped = true;
        winPanelToActivate.SetActive(true);
    }

    public void Lose()
    {
        TimeController.Instance.isTimeStopped = true;
        losePanelToActivate.SetActive(true);
    }
}
