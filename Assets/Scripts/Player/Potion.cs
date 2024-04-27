using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healthRecovered = 25;

    IHealthCanvas healthCanvas;
    IInventoryCanvas inventoryCanvas;

    private void Start()
    {
        healthCanvas = CanvasController.Instance;
        inventoryCanvas = CanvasController.Instance;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && inventoryCanvas.Inventory.potions >= 1)
        {
            UsePotion();
        }
    }

    void UsePotion()
    {
        inventoryCanvas.Inventory.potions -= 1;
        healthCanvas.HealthBar.currentHealth += healthRecovered;

        if (healthCanvas.HealthBar.currentHealth >= 100) 
        {
            healthCanvas.HealthBar.currentHealth = 100;
        }
    }
}
