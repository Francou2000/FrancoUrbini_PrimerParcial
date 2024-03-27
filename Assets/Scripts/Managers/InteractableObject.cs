using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;

    public string ItemName;

    public coreItems coreItems;

    public void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.onTarget && !this.gameObject.CompareTag("Background"))
        {
            switch (coreItems)
            {
                case coreItems.slimeCore:
                    Inventory.Instance.coreItems[0]++;
                    Destroy(this.gameObject);
                    break;
                case coreItems.mushroomCore:
                    Inventory.Instance.coreItems[3]++;
                    Destroy(this.gameObject);
                    break;
                case coreItems.cactusCore:
                    Inventory.Instance.coreItems[1]++;
                    Destroy(this.gameObject);
                    break;
                case coreItems.turtleCore:
                    Inventory.Instance.coreItems[2]++;
                    Destroy(this.gameObject);
                    break;
                case coreItems.potion:
                    Inventory.Instance.potions++;
                    Destroy(this.gameObject);
                    break;
            }
        }
    }

    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
