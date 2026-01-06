using SlimeColorShop.Decor;
using UnityEngine;

namespace SlimeColorShop.MainMenu
{
    public class MainMenuSceneManager : BaseSceneManager
    {
        [SerializeField] private DecorationHandler decorationHandler;
        [SerializeField] private GameButton playButton;
        [SerializeField] private GameButton shopButton;
        [SerializeField] private GameButton decorButton;
        [SerializeField] private ShowTextEffect showTextEffectObject;

        void Start()
        {
            decorationHandler.Init();
            playButton.Init(
                delegate
                {
                    if (InventoryManager.Instance.IsEnergyEmpty())
                    {
                        RectTransform rectTransform = playButton.GetComponent<RectTransform>();
                        ShowTextEffect instance = Instantiate(showTextEffectObject, rectTransform);
                        instance.Init(Vector2.zero, "Not enough energy!", Color.red);
                        return;
                    }
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
