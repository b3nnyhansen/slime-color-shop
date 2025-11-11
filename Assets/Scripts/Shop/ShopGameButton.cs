using UnityEngine;
using UnityEngine.UI;
using SlimeColorShop.Data;

namespace SlimeColorShop.Shop
{
    public class ShopGameButton : GameButton
    {
        [SerializeField] private Text displayText;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image itemImage;
        private ShopSceneManager shopSceneManager;
        private ShopItemEntry shopItemEntry;

        public void Init(ShopSceneManager shopSceneManager)
        {
            this.shopSceneManager = shopSceneManager;
            base.Init();
        }

        public void SetShopItemEntry(ShopItemEntry shopItemEntry)
        {
            this.shopItemEntry = shopItemEntry;
            UpdateButtonDisplay();
        }

        public void UpdateButtonDisplay()
        {
            if (shopItemEntry == null)
            {
                Utility.HideCanvasGroup(canvasGroup);
            }
            else
            {
                displayText.text = GetItemCost().ToString();
                itemImage.sprite = shopItemEntry.ItemSprite;
                Utility.ShowCanvasGroup(canvasGroup, !shopItemEntry.IsBought());
            }
        }

        public int GetItemCost()
        {
            return shopItemEntry.Cost;
        }

        protected override void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    shopSceneManager.ShowBuyConfirmationForm(shopItemEntry);
                    onClickAction?.Invoke();
                }
            );
        }
    }
}
