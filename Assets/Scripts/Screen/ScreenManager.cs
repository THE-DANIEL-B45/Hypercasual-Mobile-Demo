using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {

        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _screenBase;

        private ScreenBase randScreenBase;

        private void Start()
        {
            randScreenBase = screenBases.GetRandom();
            //transform.Scale(2);
            HideAll();
            ShowByType(startScreen);
        }

        

        public void ShowByType(ScreenType screenType)
        {
            if (_screenBase != null) _screenBase.Hide();

            var nextScreen = screenBases.Find(i => i.screenType == screenType);

            _screenBase = nextScreen;
            nextScreen.Show();
        }

        public void HideAll()
        {
            screenBases.ForEach(i => i.Hide());
        }
    }
}
