using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using UnityEngine.UI;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        InfoPanel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;

        public Image uiBackground;

        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.05f;

        private void Start()
        {
            if(startHided)
            {
                HideObjects();
            }
        }

        [Button]
        public virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();
        }

        [Button]
        public virtual void Hide()
        {
            HideObjects();
        }

        private void HideObjects()
        {
            foreach (var item in listOfObjects)
            {
                item.gameObject.SetActive(false);
            }
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            uiBackground.enabled = true;
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                listOfObjects[i].gameObject.SetActive(true);
                listOfObjects[i].DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void ForceShowObjects()
        {
            foreach (var item in listOfObjects)
            {
                item.gameObject.SetActive(true);
            }
        }

    }

}
