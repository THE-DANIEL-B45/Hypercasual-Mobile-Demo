using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBase : ItemCollectableBase
{
    [Header("PowerUp")]
    public float duration;

    protected override void OnCollect()
    {
        base.OnCollect();
        StartPowerUp();
        PlayerController.Instance.Bounce();
    }

    protected virtual void StartPowerUp()
    {
        Debug.Log("Start Power Up");
        Invoke(nameof(EndPowerUp), duration);
    }

    protected virtual void EndPowerUp()
    {
        Debug.Log("End Power Up");
    }
}
