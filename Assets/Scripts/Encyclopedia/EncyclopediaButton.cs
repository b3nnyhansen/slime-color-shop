using UnityEngine;

namespace SlimeColorShop.Encyclopedia
{
    public class EncyclopediaButton : GameButton
    {
        private bool displayState;

        public void SetDisplayState(bool displayState)
        {
            this.displayState = displayState;
        }

        public void SetEnText(string text)
        {
            enText = text;
        }

        public void SetIdText(string text)
        {
            idText = text;
        }

        public override void SetButtonText(string text)
        {
            base.SetButtonText(displayState ? text : "???");
        }

        public override void SetButtonTextLanguage()
        {
            base.SetButtonTextLanguage();
            SetButtonFontSize(60f);
        }
    }
}
