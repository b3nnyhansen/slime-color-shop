using UnityEngine;
using UnityEngine.UI;
using System;

namespace SlimeColorShop.Shop
{
    public class ShopPaginationButton : GameButton
    {
        [SerializeField] private Text displayText;
        [SerializeField] private CanvasGroup canvasGroup;
        private int pageNumber;

        public void Init(int pageNumber, Action<int> onClickAction)
        {
            SetPageNumber(pageNumber);
            base.Init(
                delegate
                {
                    onClickAction?.Invoke(this.pageNumber);
                }
            );
        }

        public void SetPageNumber(int pageNumber)
        {
            this.pageNumber = pageNumber;
            UpdateButtonDisplay();
        }

        public void UpdateButtonDisplay()
        {
            displayText.text = (pageNumber+1).ToString();
        }
    }
}
