using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class DecorationSelectButton : GameButton
    {
        private ShopItemEntry shopItemEntry;
        private int buttonValue;

        public void Init(int buttonValue, ShopItemEntry shopItemEntry, Action<int> onClickAction = null)
        {
            base.Init(
                delegate
                {
                    onClickAction?.Invoke(this.buttonValue);
                }
            );
            SetButtonValue(buttonValue);
            SetShopItemEntry(shopItemEntry);
        }
        public void SetButtonValue(int buttonValue)
        {
            this.buttonValue = buttonValue;
        }
        public void SetShopItemEntry(ShopItemEntry shopItemEntry)
        {
            this.shopItemEntry = shopItemEntry;
            SetDecorationImageSprite();
        }
        public void SetDecorationImageSprite()
        {
            if (shopItemEntry != null)
                SetDecorationImageSprite(shopItemEntry.ItemSprite);
        }
        public void SetDecorationImageSprite(Sprite sprite)
        {
            imageComponent.sprite = sprite;
        }
    }
}