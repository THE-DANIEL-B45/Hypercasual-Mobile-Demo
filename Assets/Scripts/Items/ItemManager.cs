using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI coinsText;


    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        //UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
        //UpdateUI();
    }

    private void UpdateUI()
    {
        coinsText.text = "x" + coins.value.ToString();
    }
}
