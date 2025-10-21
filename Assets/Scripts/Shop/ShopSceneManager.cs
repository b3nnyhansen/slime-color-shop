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
        int currentPageNumber = 0;
        int maxPageNumber;

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
            UpdateShopGameButtonDisplays();
        }

        private void InitDatabaseParameters()
        {
            int maxDisplayCount = shopGameButtons.Count;
            maxPageNumber = shopItemDatabase.EntryCount / maxDisplayCount;
            int leftover = shopItemDatabase.EntryCount % maxDisplayCount;
            if (leftover > 0)
                maxPageNumber++;
        }


        private void UpdateShopGameButtonDisplays()
        {
            for(int i=0; i<shopGameButtons.Count; i++)
            {
                int id = currentPageNumber * maxPageNumber + i;
                ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(id);
                shopGameButtons[i].SetShopItemEntry(shopItemEntry);
            }
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