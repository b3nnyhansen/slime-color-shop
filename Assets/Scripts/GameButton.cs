using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;

namespace SlimeColorShop
{
    public class GameButton : MonoBehaviour
    {
        protected Action onClickAction;
        protected Image imageComponent;
        protected Button buttonComponent;
        protected TextMeshProUGUI buttonTextComponent;

        public virtual void Init(Action onClickAction = null)
        {
            this.onClickAction = onClickAction;
            imageComponent = gameObject.GetComponent<Image>();
            buttonComponent = gameObject.GetComponent<Button>();
            try
            {
                buttonTextComponent = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            }
            catch
            {
                buttonTextComponent = null;
            }
            SetOnClickAction();
        }

        protected virtual void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    onClickAction?.Invoke();
                }
            );
        }

        public virtual void SetButtonText(string text)
        {
            if(buttonTextComponent != null)
                buttonTextComponent.text = text;
        }

        public virtual void SetButtonColor(float r, float g, float b)
        {
            imageComponent.color = new Color(r, g, b);
        }

        public void SetButtonColor(ColorQuestionEntry entry)
        {
            SetButtonColor(entry.R / 255f, entry.G / 255f, entry.B / 255f);
        }
    }
}
