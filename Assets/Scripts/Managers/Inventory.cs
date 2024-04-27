using UnityEngine;

public class Inventory : MonoBehaviour
{
    //slime = 0, cactus = 1, turtle = 2, mushroom = 3 
    public int[] coreItems = new int[4];
    public int potions = 0;

    IInventoryCanvas inventoryCanvas;

    public static Inventory Instance { get; private set; }

    public void Awake()
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
        inventoryCanvas = CanvasController.Instance;
    }

    public void Update()
    {
        inventoryCanvas.Inventory.potions = potions;
        inventoryCanvas.Inventory.coreItems[0] = coreItems[0];
        inventoryCanvas.Inventory.coreItems[1] = coreItems[1];
        inventoryCanvas.Inventory.coreItems[2] = coreItems[2];
        inventoryCanvas.Inventory.coreItems[3] = coreItems[3];
    }
}
