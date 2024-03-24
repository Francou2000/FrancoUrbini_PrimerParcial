using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public GameObject interactionInfoUI;
    TextMeshProUGUI interactionText;

    private void Start()
    {
        interactionText = interactionInfoUI.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            var selectionTransform = hit.transform;

            if (selectionTransform.GetComponent<InteractableObject>())
            {
                if (selectionTransform.tag == "Enemy")
                {
                    interactionText.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                    interactionText.color = Color.red;
                    interactionInfoUI.SetActive(true);
                }
                else
                {
                    interactionText.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                    interactionText.color = Color.white;
                    interactionInfoUI.SetActive(true);
                }
            }
            else
            {
                interactionInfoUI.SetActive(false);
            }
        }
        else
        {
            interactionInfoUI.SetActive(false);
        }
    }
}