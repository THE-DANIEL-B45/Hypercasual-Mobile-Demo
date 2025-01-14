using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float finalScale = 1.2f;
    public float scaleDuration = 0.1f;

    private Vector3 defaultScale;

    private Tween _currentTween;

    private void Awake()
    {
        defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
        _currentTween = transform.DOScale(defaultScale * finalScale, scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
        _currentTween.Kill();
        transform.localScale = defaultScale;
    }
}
