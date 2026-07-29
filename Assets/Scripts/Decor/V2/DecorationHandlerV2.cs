using System;
using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.MainMenu
{
    public class DecorationHandlerV2 : MonoBehaviour
    {
        [SerializeField] private List<DecorationButtonV2> decorationButtons;
        
        public void Init(Action<int> onClickAction = null)
        {
            InitDecorationButtons(onClickAction);
        }

        private void InitDecorationButtons(Action<int> onClickAction)
        {
            ShopItemDatabase shopItemDatabase = InventoryManager.Instance.GetShopItemDatabase();
            DecorationDatabase decorationDatabase = InventoryManager.Instance.GetDecorationDatabase();

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
            DecorationButtonV2 selectedDecorationButton = decorationButtons[decorationButtonId];
            selectedDecorationButton.SetShopItemEntry(shopItemEntry);
        }
    }
}