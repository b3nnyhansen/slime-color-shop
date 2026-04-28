using System;
using UnityEngine;
using TMPro;

namespace SlimeColorShop.Shop
{
    public class ShopBuyConfirmationForm : BaseFormHandler
    {
        [SerializeField] private GameButton buyButton;
        [SerializeField] private GameButton cancelButton;
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private string enMessage;
        [SerializeField] private string idMessage;

        public void Init(
            Action onBuyButtonClickAction
        )
        {
            buyButton.Init(onBuyButtonClickAction);
            cancelButton.Init(HideCanvasGroup);
            SetMessageTextLanguage();
            base.Init();
        }

        public void Show()
        {
            ShowCanvasGroup();
        }

        public void SetMessageText(string message)
        {
            messageText.text = message;
        }

        public void SetMessageTextLanguage()
        {
            string text = InventoryManager.Instance.IsGameLanguageEN() ? enMessage : idMessage;
            SetMessageText(text);
        }
    }
}