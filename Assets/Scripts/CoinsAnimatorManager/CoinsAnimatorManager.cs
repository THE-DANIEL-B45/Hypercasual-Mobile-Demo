using DG.Tweening;
using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinsAnimatorManager : Singleton<CoinsAnimatorManager>
{
    public List<ItemCollectableCoin> items = new List<ItemCollectableCoin>();

    [Header("Animation")]
    public float scaleDuration = 0.2f;
    public float scaleTimeBetweenPieces = 0.1f;
    public Ease ease = Ease.OutBack;

    public void RegisterCoin(ItemCollectableCoin i)
    {
        if(!items.Contains(i))
        {
            items.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePiecesByTime());
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach (var p in items)
        {
            p.transform.localScale = Vector3.zero;
        }

        Sort();

        yield return null;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
    }

    private void Sort()
    {
        items = items.OrderBy(
            x => Vector3.Distance(this.transform.position, x.transform.position)).ToList();
    }

}
