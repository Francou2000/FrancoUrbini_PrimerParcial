using UnityEngine;

public class CanvasController : MonoBehaviour, IInventoryCanvas, IHealthCanvas
{
    public HealthBar HealthBar => healthBar;
    public InventoryCanvas Inventory => inventory;

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private InventoryCanvas inventory;

    public static CanvasController Instance { get; private set; }

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
}
