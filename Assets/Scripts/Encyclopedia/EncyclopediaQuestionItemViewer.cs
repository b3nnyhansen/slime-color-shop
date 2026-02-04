using UnityEngine;
using SlimeColorShop.Data;
using TMPro;

namespace SlimeColorShop.Encyclopedia
{
    public class EncyclopediaQuestionItemViewer : BaseFormHandler
    {
        [SerializeField] private TextMeshProUGUI colorNameText;
        [SerializeField] private TextMeshProUGUI colorHexcodeText;
        [SerializeField] private TextMeshProUGUI colorLikePhraseText;
        [SerializeField] private TextMeshProUGUI colorCombinationPhraseText;

        public void SetTexts(ColorQuestionEntry entry, int displayState = 0)
        {
            colorNameText.text = (displayState & 1) > 0 ? entry.ColorName : "???";
            colorHexcodeText.text = (displayState & 2) > 0 ? entry.ColorHexCode : "???";
            colorLikePhraseText.text = (displayState & 4) > 0 ? entry.ColorLikePhrase : "???";
            colorCombinationPhraseText.text = (displayState & 8) > 0 ? entry.ColorCombinationPhrase : "???";
        }

        public void ShowQuestionItem(ColorQuestionEntry entry, int displayState = 0)
        {
            SetTexts(entry, displayState);
            ShowCanvasGroup();
        }
    }
}
