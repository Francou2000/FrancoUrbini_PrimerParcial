using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public TextMeshProUGUI pCounter;
    public TextMeshProUGUI scCounter;
    public TextMeshProUGUI ccCounter;
    public TextMeshProUGUI tcCounter;
    public TextMeshProUGUI mcCounter;
    public static Inventory Instance { get; private set; }

    public int potions = 0;

    //slime = 0, cactus = 1, turtle = 2, mushroom = 3 
    public int[] coreItems = new int [4];

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

    private void Update()
    {
        pCounter.text = potions.ToString();
        scCounter.text = coreItems[0].ToString();
        ccCounter.text = coreItems[1].ToString();
        mcCounter.text = coreItems[3].ToString();
        tcCounter.text = coreItems[2].ToString();
    }
}
