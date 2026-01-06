using UnityEngine;

namespace SlimeColorShop.Gameplay
{
    public class GameplayOverlayManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        [SerializeField] private PauseScreen pauseScreen;
        [SerializeField] private GameOverScreen gameOverScreen;

        public void Init()
        {
            pauseScreen.Init();
            gameOverScreen.Init();
            Hide();
        }

        public void Show()
        {
            Utility.ShowCanvasGroup(canvasGroupComponent);
        }

        public void Hide()
        {
            Utility.HideCanvasGroup(canvasGroupComponent);
        }

        public void ShowPauseScreen()
        {
            pauseScreen.Show();
            gameOverScreen.Hide();
            Show();
        }

        public void ShowGameOverScreen(int score=0, int maxScore=0)
        {
            pauseScreen.Hide();
            gameOverScreen.ShowScore(score, maxScore);
            Show();
        }
    }
}