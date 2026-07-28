using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimeColorShop.Gameplay
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        [SerializeField] private GameButtonV3 menuButton;
        [SerializeField] private GameButtonV3 replayButton;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private Image headerImage;

        public void Init()
        {
            InitButtons();
        }

        private void InitButtons()
        {
            menuButton.Init(
                delegate
                {
                    GameplaySceneManager.Instance.LoadMainMenuScene();
                }
            );
            replayButton.Init(
                delegate
                {
                    GameplaySceneManager.Instance.LoadGameplayScene();
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

        public void SetScoreText(int score)
        {
            scoreText.text = string.Format("{0}", score);
        }

        public void SetCoinText(int coin)
        {
            scoreText.text = string.Format("{0}", coin);
        }

        public void ShowScore(int score, int maxScore, int coin)
        {
            if (score < maxScore)
            {
                HideHeaderImage();
            }
            else
            {
                ShowHeaderImage();
            }
            SetScoreText(score);
            SetCoinText(coin);
            Show();
        }

        public void ShowHeaderImage()
        {
            headerImage.color = Color.white;
        }

        public void HideHeaderImage()
        {
            headerImage.color = Color.clear;
        }
    }
}