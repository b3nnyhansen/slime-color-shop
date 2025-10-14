using UnityEngine;
using SlimeColorShop.Data;

namespace SlimeColorShop.Shop
{
    public class ShopGameButton : GameButton
    {
        [SerializeField] private ShopItemEntry shopItemEntry;

        public int GetItemCost()
        {
            return shopItemEntry.Cost;
        }

        protected override void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    InventoryManager.Instance.AddCoin(-GetItemCost());
                    onClickAction?.Invoke();
                }
            );
        }
    }
}
