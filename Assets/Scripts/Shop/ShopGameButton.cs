using UnityEngine;
using UnityEngine.UI;
using SlimeColorShop.Data;

namespace SlimeColorShop.Shop
{
    public class ShopGameButton : GameButton
    {
        [SerializeField] private ShopItemEntry shopItemEntry;
        [SerializeField] private Text displayText;
        [SerializeField] private CanvasGroup canvasGroup;

        public void SetShopItemEntry(ShopItemEntry shopItemEntry)
        {
            this.shopItemEntry = shopItemEntry;
            UpdateButtonDisplay();
        }

        public void UpdateButtonDisplay()
        {
            if (shopItemEntry == null)
                Utility.HideCanvasGroup(canvasGroup);
            else
                displayText.text = shopItemEntry.Cost.ToString();
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
                    int cost = GetItemCost();
                    if (!InventoryManager.Instance.IsCostLessThanCoin(cost))
                        return;

                    InventoryManager.Instance.AddCoin(-cost);
                    onClickAction?.Invoke();
                }
            );
        }
    }
}
