using UnityEngine;

namespace SlimeColorShop.MainMenu
{
    public class MainMenuSceneManager : BaseSceneManager
    {
        [SerializeField] private GameButton playButton;
        [SerializeField] private GameButton shopButton;
        [SerializeField] private GameButton decorButton;

        void Start()
        {
            playButton.Init(
                delegate
                {
                    if (InventoryManager.Instance.IsEnergyEmpty())
                        return;
                    LoadScene(SceneNameEnum.GAMEPLAY);
                }
            );
            shopButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.SHOP);
                }
            );
            decorButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.DECOR);
                }
            );
        }
    }
}
