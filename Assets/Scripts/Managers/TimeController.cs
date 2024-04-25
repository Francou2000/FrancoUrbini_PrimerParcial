using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance { get; private set; }

    public bool isTimeStopped = false;

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
        if (isTimeStopped)
        {
            Time.timeScale = 0f;
        }
        else
        {
           Time.timeScale = 1f;
        }
    }
}
