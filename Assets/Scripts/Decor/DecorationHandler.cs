using System;
using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Decor
{
    public class DecorationHandler : MonoBehaviour
    {
        [SerializeField] private List<DecorationButton> decorationButtons;

        public void Init(Action<int> onClickAction = null)
        {
            Init(
                InventoryManager.Instance.GetShopItemDatabase(),
                InventoryManager.Instance.GetDecorationDatabase(),
                onClickAction
            );
        }

        public void Init(
            ShopItemDatabase shopItemDatabase,
            DecorationDatabase decorationDatabase,
            Action<int> onClickAction
        )
        {
            for (int i = 0; i < decorationDatabase.EntryCount; i++)
            {
                DecorationEntry decorationEntry = decorationDatabase.GetEntry(i);
                int shopItemEntryId = (int)decorationEntry.LoadData();
                if (shopItemEntryId < 0)
                {
                    decorationButtons[i].Init(
                        i,
                        null,
                        onClickAction
                    );
                }
                else
                {
                    ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(shopItemEntryId);
                    decorationButtons[i].Init(
                        i,
                        shopItemEntry,
                        onClickAction
                    );
                }
            }
        }

        public void SetDecorationButtonShopItemEntry(int decorationButtonId, ShopItemEntry shopItemEntry)
        {
            DecorationButton selectedDecorationButton = decorationButtons[decorationButtonId];
            selectedDecorationButton.SetShopItemEntry(shopItemEntry);
        }
    }
}