using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Shop
{
    public class ShopSceneManager : BaseSceneManager
    {
        [SerializeField] private GameButton returnButton;
        [SerializeField] private List<ShopGameButton> shopGameButtons;
        [SerializeField] private ShopPaginationButton shopPaginationButtonObject;
        [SerializeField] private RectTransform paginationTransform;
        [SerializeField] private ShopBuyConfirmationForm shopBuyConfirmationForm;
        private ShopItemDatabase shopItemDatabase;
        private ShopItemEntry onHoldShopItemEntry;
        int currentPageNumber = 0;
        int maxPageNumber;
        int maxDisplayCount;

        void Start()
        {
            returnButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.MAIN_MENU);
                }
            );
            shopBuyConfirmationForm.Init(ConfirmPurchase);
            InitShopGameButtons();
        }

        private void InitShopGameButtons()
        {
            InitDatabaseParameters();
            foreach (ShopGameButton shopGameButton in shopGameButtons)
                shopGameButton.Init(this);
            if (maxPageNumber > 1)
            {
                for(int pageNumber=0; pageNumber<maxPageNumber; pageNumber++)
                {
                    ShopPaginationButton instance = Instantiate(shopPaginationButtonObject, paginationTransform);
                    instance.Init(pageNumber, SetCurrentPageNumber);
                }
            }
            UpdateShopGameButtonsEntry();
        }

        private void InitDatabaseParameters()
        {
            maxDisplayCount = shopGameButtons.Count;
            shopItemDatabase = InventoryManager.Instance.GetShopItemDatabase();
            maxPageNumber = shopItemDatabase.EntryCount / maxDisplayCount;
            int leftover = shopItemDatabase.EntryCount % maxDisplayCount;
            if (leftover > 0)
                maxPageNumber++;
        }

        private void UpdateShopGameButtonsEntry()
        {
            for (int i = 0; i < shopGameButtons.Count; i++)
            {
                int id = currentPageNumber * maxDisplayCount + i;
                ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(id);
                shopGameButtons[i].SetShopItemEntry(shopItemEntry);
            }
        }

        private void UpdateShopGameButtonsDisplay()
        {
            foreach (ShopGameButton shopGameButton in shopGameButtons)
                shopGameButton.UpdateButtonDisplay();
        }

        public void SetOnHoldShopItemEntry(ShopItemEntry shopItemEntry)
        {
            onHoldShopItemEntry = shopItemEntry;
        }

        public void ShowBuyConfirmationForm(ShopItemEntry shopItemEntry)
        {
            SetOnHoldShopItemEntry(shopItemEntry);
            shopBuyConfirmationForm.Show();
        }

        public void ConfirmPurchase()
        {
            int cost = onHoldShopItemEntry.Cost;
            if (!InventoryManager.Instance.IsCostLessThanCoin(cost))
            {
                shopBuyConfirmationForm.SetMessageText("Jumlah koin tidak mencukupi.");
            }
            else
            {
                InventoryManager.Instance.AddCoin(-cost);
                onHoldShopItemEntry.SaveData();
                UpdateShopGameButtonsDisplay();
                shopBuyConfirmationForm.HideCanvasGroup();
            }
        }
        
        public void SetCurrentPageNumber(int pageNumber)
        {
            currentPageNumber = pageNumber;
            UpdateShopGameButtonsEntry();
        }
    }
}