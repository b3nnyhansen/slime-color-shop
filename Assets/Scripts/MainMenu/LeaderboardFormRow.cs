using UnityEngine;
using TMPro;

namespace SlimeColorShop.MainMenu
{
    public class LeaderboardFormRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI numberText;
        [SerializeField] private TextMeshProUGUI scoreText;

        public void Init(string numberText, string scoreText)
        {
            SetNumberText(numberText);
            SetScoreText(scoreText);
        }

        public void SetNumberText(string numberText)
        {
            this.numberText.text = numberText;
        }

        public void SetScoreText(string scoreText)
        {
            this.scoreText.text = scoreText;
        }
    }
}