using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

                if (selectionTransform.tag == "Enemy")
                {
                    interactionText.text = interactableObject.GetItemName();
                    interactionText.color = Color.red;
                    interactionInfoUI.SetActive(true);
                }
                else
                {
                    interactionText.text = interactableObject.GetItemName();
                    interactionText.color = Color.white;
                    interactionInfoUI.SetActive(true);
                }
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