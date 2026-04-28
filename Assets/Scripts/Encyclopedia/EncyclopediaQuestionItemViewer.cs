using UnityEngine;
using UnityEngine.UI;
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

        private ColorQuestionEntry entry;
        private int displayState;

        public void SetTexts(ColorQuestionEntry entry, int displayState = 0)
        {
            this.entry = entry;
            this.displayState = displayState;
            SetTexts();
        }

        public void SetTexts()
        {
            GameLanguageEnum language = InventoryManager.Instance.GetGameLanguage();
            colorNameText.text = (displayState & 1) > 0 ? entry.GetColorName(language) : "???";
            colorHexcodeText.text = (displayState & 2) > 0 ? entry.GetColorHexCode(language) : "???";
            colorLikePhraseText.text = (displayState & 4) > 0 ? entry.GetLikePhrase(language) : "???";
            colorCombinationPhraseText.text = (displayState & 8) > 0 ? entry.GetCombinationPhrase(language) : "???";

            SetTextFontSize(colorNameText, 108f);
            SetTextFontSize(colorHexcodeText, 72);
            SetTextFontSize(colorLikePhraseText, 48);
            SetTextFontSize(colorCombinationPhraseText, 48f);
        }

        public void ShowQuestionItem(ColorQuestionEntry entry, int displayState = 0)
        {
            SetTexts(entry, displayState);
            ShowCanvasGroup();
        }

        public void SetTextFontSize(TextMeshProUGUI textComponent, float fontSize, float minSize = 900f)
        {
            textComponent.fontSize = fontSize;

            RectTransform rectTransform = textComponent.GetComponent<RectTransform>();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            float preferredWidth = Utility.GetPreferredWidth(rectTransform);

            if(preferredWidth > minSize)
                textComponent.fontSize *= minSize / preferredWidth * 0.95f;
        }
    }
}
