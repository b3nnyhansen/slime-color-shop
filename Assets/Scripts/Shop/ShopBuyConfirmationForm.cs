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

        public void Init(
            Action onBuyButtonClickAction
        )
        {
            buyButton.Init(onBuyButtonClickAction);
            cancelButton.Init(HideCanvasGroup);
            base.Init();
        }

        public void Show()
        {
            SetMessageText("Apa kamu ingin membeli barang ini?");
            ShowCanvasGroup();
        }

        public void SetMessageText(string message)
        {
            messageText.text = message;
        }
    }
}