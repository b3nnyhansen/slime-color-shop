using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class DecorationSelectButton : GameButton
    {
        [SerializeField] private Image imageComponent;
        private ShopItemEntry shopItemEntry;
        private int buttonValue;

        public void Init(int buttonValue, ShopItemEntry shopItemEntry, Action<int> onClickAction = null)
        {
            SetButtonValue(buttonValue);
            SetShopItemEntry(shopItemEntry);
            base.Init(
                delegate
                {
                    onClickAction?.Invoke(this.buttonValue);
                }
            );
        }
        public void SetButtonValue(int buttonValue)
        {
            this.buttonValue = buttonValue;
        }
        public void SetShopItemEntry(ShopItemEntry shopItemEntry)
        {
            this.shopItemEntry = shopItemEntry;
            SetImageSprite();
        }
        public void SetImageSprite()
        {
            if (shopItemEntry != null)
                SetImageSprite(shopItemEntry.ItemSprite);
        }
        public void SetImageSprite(Sprite sprite)
        {
            imageComponent.sprite = sprite;
        }
    }
}