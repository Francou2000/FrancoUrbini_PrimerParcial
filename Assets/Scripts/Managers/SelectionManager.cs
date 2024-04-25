using TMPro;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; set; }
    
    public bool onTarget = false;

    public GameObject interactionInfoUI;
    TextMeshProUGUI interactionText;

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

    private void Start()
    {
        interactionText = interactionInfoUI.GetComponent<TextMeshProUGUI>();

        Cursor.visible = false;
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractableObject interactableObject = selectionTransform.GetComponent<InteractableObject>();

            if (interactableObject && interactableObject.playerInRange)
            {
                onTarget = true;
               
                interactionText.text = interactableObject.GetItemName();
                interactionInfoUI.SetActive(true);
            }
            else
            {
                onTarget = false;

                interactionInfoUI.SetActive(false);
            }
        }
        else
        {
            onTarget = false;

            interactionInfoUI.SetActive(false);
        }
    }
}