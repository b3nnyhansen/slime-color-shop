using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeColorShop.Shop
{
    public class ShopSceneManager : MonoBehaviour
    {
        [SerializeField] private GameButton returnButton;
        [SerializeField] private List<ShopGameButton> shopGameButtons;
        [SerializeField] private ShopItemDatabase shopItemDatabase;
        [SerializeField] private ShopPaginationButton shopPaginationButtonObject;
        [SerializeField] private RectTransform paginationTransform;
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
            InitShopGameButtons();
        }

        private void InitShopGameButtons()
        {
            InitDatabaseParameters();
            foreach (ShopGameButton shopGameButton in shopGameButtons)
                shopGameButton.Init();
            if (maxPageNumber > 1)
            {
                for(int pageNumber=0; pageNumber<maxPageNumber; pageNumber++)
                {
                    ShopPaginationButton instance = Instantiate(shopPaginationButtonObject, paginationTransform);
                    instance.Init(pageNumber, SetCurrentPageNumber);
                }
            }
            UpdateShopGameButtonDisplays();
        }

        private void InitDatabaseParameters()
        {
            maxDisplayCount = shopGameButtons.Count;
            maxPageNumber = shopItemDatabase.EntryCount / maxDisplayCount;
            int leftover = shopItemDatabase.EntryCount % maxDisplayCount;
            if (leftover > 0)
                maxPageNumber++;
            Debug.Log(maxPageNumber);
        }

        private void UpdateShopGameButtonDisplays()
        {
            for (int i = 0; i < shopGameButtons.Count; i++)
            {
                int id = currentPageNumber * maxDisplayCount + i;
                ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(id);
                shopGameButtons[i].SetShopItemEntry(shopItemEntry);
            }
        }
        
        public void SetCurrentPageNumber(int pageNumber)
        {
            currentPageNumber = pageNumber;
            UpdateShopGameButtonDisplays();
        }
        
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadScene(SceneNameEnum sceneNameEnum)
        {
            LoadScene((int)sceneNameEnum);
        }
    }
}