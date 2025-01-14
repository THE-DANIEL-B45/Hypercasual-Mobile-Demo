using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

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
        protected virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();
        }

        [Button]
        protected virtual void Hide()
        {
            HideObjects();
        }

        private void HideObjects()
        {
            foreach (var item in listOfObjects)
            {
                item.gameObject.SetActive(false);
            }
        }

        private void ShowObjects()
        {
            for(int i = 0; i < listOfObjects.Count; i++)
            {
                listOfObjects[i].gameObject.SetActive(true);
                listOfObjects[i].DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
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
