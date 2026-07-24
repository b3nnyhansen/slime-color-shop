using UnityEngine;
using TMPro;

namespace SlimeColorShop.MainMenu
{
    public class LeaderboardFormRow : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI timestampText;

        public void Init(string scoreText, string timestampText)
        {
            SetScoreText(scoreText);
            SetTimestampText(timestampText);
        }

        public void SetScoreText(string scoreText)
        {
            this.scoreText.text = scoreText;
        }

        public void SetTimestampText(string timestampText)
        {
            this.timestampText.text = timestampText;
        }
    }
}