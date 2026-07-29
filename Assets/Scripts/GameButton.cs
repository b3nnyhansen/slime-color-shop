using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public class GameButton : BaseGameButton
    {
        protected TextMeshProUGUI buttonTextComponent;
        protected Color originalButtonBackgroundColor;
        protected Color originalButtonFontColor;
        [SerializeField] protected string enText;
        [SerializeField] protected string idText;

        public override void Init(Action onClickAction = null)
        {
            base.Init(onClickAction);
            try
            {
                buttonTextComponent = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            }
            catch
            {
                buttonTextComponent = null;
            }

            originalButtonBackgroundColor = imageComponent.color;
            if(buttonTextComponent != null)
                originalButtonFontColor = buttonTextComponent.color;

            SetButtonTextLanguage();
        }

        public virtual void SetButtonText(string text)
        {
            if(buttonTextComponent != null)
                buttonTextComponent.text = text;
        }

        public virtual void SetButtonColor(Color color)
        {
            imageComponent.color = color;
        }

        public virtual void SetButtonColor(float r, float g, float b)
        {
            SetButtonColor(new Color(r, g, b));
        }

        public void SetButtonColor(ColorQuestionEntry entry)
        {
            SetButtonColor(entry.R / 255f, entry.G / 255f, entry.B / 255f);
        }

        public virtual void SetButtonFontSize(float fontSize, float minSize = 270f)
        {
            if(buttonTextComponent == null)
                return;
            buttonTextComponent.fontSize = fontSize;

            RectTransform rectTransform = buttonTextComponent.GetComponent<RectTransform>();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            float preferredWidth = Utility.GetPreferredWidth(rectTransform);
            
            if(preferredWidth > minSize)
                buttonTextComponent.fontSize *= minSize / preferredWidth * 0.95f;
        }

        public virtual void SetButtonFontColor(Color color)
        {
            if(buttonTextComponent != null)
                buttonTextComponent.color = color;
        }

        public virtual void SetButtonInvisible()
        {
            SetButtonColor(Color.clear);
            SetButtonFontColor(Color.clear);
        }

        public virtual void SetButtonVisible()
        {
            SetButtonColor(originalButtonBackgroundColor);
            SetButtonFontColor(originalButtonFontColor);
        }

        public virtual void SetButtonTextLanguage()
        {
            string text = InventoryManager.Instance.IsGameLanguageEN() ? enText : idText;
            SetButtonText(text);
        }
    }
}
