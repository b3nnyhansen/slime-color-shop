using System;
using System.Collections.Generic;
using SlimeColorShop.Audio;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.MainMenu
{
    public class DecorationButtonV2 : BaseGameButton
    {
        [SerializeField] private Sprite defaultSprite;
        private ShopItemEntry shopItemEntry;
        private int buttonValue;

        public void Init(int buttonValue, ShopItemEntry shopItemEntry, Action<int> onClickAction = null)
        {
            base.Init(
                delegate
                {
                    onClickAction?.Invoke(this.buttonValue);
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
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
            SetPlacementData(shopItemEntry);
            this.shopItemEntry = shopItemEntry;
            SetDecorationImageSprite();
        }
        public void SetDecorationImageSprite()
        {
            if (shopItemEntry == null)
                SetDecorationImageSprite(null);
            else
                SetDecorationImageSprite(shopItemEntry.ItemSprite);
        }
        public void SetDecorationImageSprite(Sprite sprite)
        {
            if (sprite == null)
            {
                imageComponent.sprite = defaultSprite;
            }
            else
            {
                imageComponent.sprite = sprite;
            }
        }
        private void SetPlacementData(ShopItemEntry shopItemEntry)
        {
            if (this.shopItemEntry != null)
                this.shopItemEntry.UnsetPlacementData();
            if (shopItemEntry != null)
                shopItemEntry.SetPlacementData();
        }
    }
}