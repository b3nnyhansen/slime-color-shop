using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimeColorShop.Gameplay
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        [SerializeField] private Button menuButton;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Init()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            menuButton.onClick.AddListener(
                delegate
                {
                    GameplaySceneManager.Instance.LoadMainMenuScene();
                }
            );
        }

        public void Show()
        {
            Utility.ShowCanvasGroup(canvasGroupComponent);
        }

        public void Hide()
        {
            Utility.HideCanvasGroup(canvasGroupComponent);
        }

        public void SetScoreText(int score, int maxScore)
        {
            scoreText.text = string.Format("Score: {0}\nMax Score: {1}", score, maxScore);
        }

        public void ShowScore(int score, int maxScore)
        {
            SetScoreText(score, maxScore);
            Show();
        }
    }
}