using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanelToActivate;
    [SerializeField] private GameObject losePanelToActivate;

    IHealthCanvas healthCanvas;

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

    public void Start()
    {
        healthCanvas = CanvasController.Instance;
    }

    void Update()
    {
        if(healthCanvas.HealthBar.currentHealth <= 0)
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
