using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeColorShop.Shop
{
    public class ShopSceneManager : MonoBehaviour
    {
        [SerializeField] private GameButton returnButton;
        [SerializeField] private List<ShopGameButton> shopGameButtons;

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
            foreach (ShopGameButton shopGameButton in shopGameButtons)
                shopGameButton.Init();
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