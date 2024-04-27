using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI healthCounter;

    public GameObject playerState;

    public float currentHealth;
    private float maxHealth = 100;

    void Start()
    {
        slider = GetComponent<Slider>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        float fillValue = currentHealth / maxHealth;
        slider.value = fillValue;

        healthCounter.text = currentHealth + "/" + maxHealth;
    }
}
