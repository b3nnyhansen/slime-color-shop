using System;
using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Decor
{
    public class DecorSceneManager : BaseSceneManager
    {
        [SerializeField] private GameButton returnButton;
        [SerializeField] private List<DecorationButton> decorationButtons;
        [SerializeField] private DecorationSelectionManager decorationSelectionManager;
        private ShopItemDatabase shopItemDatabase;
        private DecorationDatabase decorationDatabase;
        private int selectedDecorationButtonId;
        private int selectedShopItemEntryId;

        void Start()
        {
            returnButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.MAIN_MENU);
                }
            );
            InitSceneParameters();
            InitDecorationButtons();
            InitDecorationSelectionManager();
        }

        private void InitSceneParameters()
        {
            shopItemDatabase = InventoryManager.Instance.GetShopItemDatabase();
            decorationDatabase = InventoryManager.Instance.GetDecorationDatabase();
        }

        private void InitDecorationButtons()
        {
            for (int i = 0; i < decorationDatabase.EntryCount; i++)
            {
                DecorationEntry decorationEntry = decorationDatabase.GetEntry(i);
                int shopItemEntryId = (int)decorationEntry.LoadData();
                Action onClickAction = delegate
                {
                    OpenDecorationSelection(i);
                };
                if (shopItemEntryId < 0)
                {
                    decorationButtons[i].Init(
                        i,
                        null,
                        OpenDecorationSelection
                    );
                }
                else
                {
                    ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(shopItemEntryId);
                    decorationButtons[i].Init(
                        i,
                        shopItemEntry,
                        OpenDecorationSelection
                    );
                }
            }
        }

        private void InitDecorationSelectionManager()
        {
            decorationSelectionManager.Init(this, shopItemDatabase);
        }

        private void OpenDecorationSelection(int decorationButtonId)
        {
            SetSelectedDecorationButtonId(decorationButtonId);
            decorationSelectionManager.ShowCanvasGroup();
        }

        public void SetSelectedDecorationButtonId(int selectedDecorationButtonId)
        {
            this.selectedDecorationButtonId = selectedDecorationButtonId;
        }

        public void SetSelectedShopItemEntryId(int selectedShopItemEntryId)
        {
            this.selectedShopItemEntryId = selectedShopItemEntryId;
        }

        public void SaveDecoration()
        {
            DecorationEntry decorationEntry = decorationDatabase.GetEntry(selectedDecorationButtonId);
            decorationEntry.SaveData(selectedShopItemEntryId);
            
            ShopItemEntry shopItemEntry = selectedShopItemEntryId < 0 ? null : shopItemDatabase.GetEntry(selectedShopItemEntryId);
            DecorationButton selectedDecorationButton = decorationButtons[selectedDecorationButtonId];
            selectedDecorationButton.SetShopItemEntry(shopItemEntry);
        }
    }
}
