using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Gameplay
{
    public class PauseScreen : BaseFormHandler
    {
        [SerializeField] private GameButton resumeButton;
        [SerializeField] private GameButton menuButton;

        public override void Init()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            resumeButton.Init(
                delegate
                {
                    GameplaySceneManager.Instance.HidePauseScreen();
                }
            );
            menuButton.Init(
                delegate
                {
                    GameplaySceneManager.Instance.LoadMainMenuScene();
                }
            );
            outerScreenButton.onClick.AddListener(
                delegate
                {
                    GameplaySceneManager.Instance.HidePauseScreen();
                }
            );
        }

        public void Show()
        {
            ShowCanvasGroup();
        }

        public void Hide()
        {
            HideCanvasGroup();
        }
    }
}
