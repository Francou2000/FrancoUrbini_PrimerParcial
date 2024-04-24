using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool playerInRange;

    public string ItemName;

    public coreItems coreItems;

    private IPickUp pickUp;

    private void Start()
    {
        
        switch (coreItems)
        {
            case coreItems.slimeCore:
                pickUp = new SlimeCorePickUp();
                break;
            case coreItems.mushroomCore:
                pickUp = new MushroomCorePickUp();
                break;
            case coreItems.turtleCore:
                pickUp = new TurtleCorePickUp();
                break;
            case coreItems.cactusCore:
                pickUp = new CactusCorePickUp();
                break;
            case coreItems.potion:
                pickUp = new PotionPickUp();
                break;
            default:
                break;       
        }
    }

    public void Update()
    {
        PickUp();
    }

    void PickUp()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.onTarget && !this.gameObject.CompareTag("Background"))
        {
            pickUp.PickUp();
            Destroy(this.gameObject);        
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

