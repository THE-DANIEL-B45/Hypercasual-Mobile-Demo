using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public int amount;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(amount);
    }
}
