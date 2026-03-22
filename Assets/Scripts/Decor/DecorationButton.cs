using System;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class DecorationButton : GameButton
    {
        [SerializeField] private Sprite defaultSprite;
        private ShopItemEntry shopItemEntry;
        private int buttonValue;
        private bool isShowingDefaultSprite;

        public void Init(int buttonValue, ShopItemEntry shopItemEntry, Action<int> onClickAction = null, bool isShowingDefaultSprite = false)
        {
            base.Init(
                delegate
                {
                    onClickAction?.Invoke(this.buttonValue);
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
            this.isShowingDefaultSprite = isShowingDefaultSprite;
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
            if (shopItemEntry == null)
                SetDecorationImageSprite(null);
            else
                SetDecorationImageSprite(shopItemEntry.ItemSprite);
        }
        public void SetDecorationImageSprite(Sprite sprite)
        {
            if (sprite == null)
            {
                if (isShowingDefaultSprite)
                    imageComponent.sprite = defaultSprite;
                else
                    imageComponent.color = Color.clear;
            }
            else
            {
                imageComponent.sprite = sprite;
                imageComponent.color = Color.white;
            }
                
        }
    }
}
