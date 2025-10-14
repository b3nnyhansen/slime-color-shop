using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeColorShop.MainMenu
{
    public class MainMenuSceneManager : MonoBehaviour
    {
        [SerializeField] private GameButton playButton;
        [SerializeField] private GameButton shopButton;

        void Start()
        {
            playButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.GAMEPLAY);
                }
            );
            shopButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.SHOP);
                }
            );
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
