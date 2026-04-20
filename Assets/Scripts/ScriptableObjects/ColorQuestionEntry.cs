using System;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ColorQuestion", menuName = "Data/ColorQuestion")]
    public class ColorQuestionEntry : ScriptableObject
    {
        public int R;
        public int G;
        public int B;
        public string ColorName_EN;
        public string ColorHexCode_EN;
        public string ColorLikePhrase_EN;
        public string ColorCombinationPhrase_EN;
        public string ColorName_ID;
        public string ColorHexCode_ID;
        public string ColorLikePhrase_ID;
        public string ColorCombinationPhrase_ID;

        public bool IsAnswerCorrect(int r, int g, int b, int threshold = 0)
        {
            return
                Math.Abs(R - r) <= threshold &&
                Math.Abs(G - g) <= threshold &&
                Math.Abs(B - b) <= threshold;
        }

        public string GetColorName(ColorQuestionLanguage language = ColorQuestionLanguage.EN)
        {
            switch (language)
            {
                case ColorQuestionLanguage.EN:
                    return ColorName_EN;
                case ColorQuestionLanguage.ID:
                    return ColorName_ID;
                default:
                    return ColorName_EN;
            }
        }

        public string GetColorHexCode(ColorQuestionLanguage language = ColorQuestionLanguage.EN)
        {
            switch (language)
            {
                case ColorQuestionLanguage.EN:
                    return ColorHexCode_EN;
                case ColorQuestionLanguage.ID:
                    return ColorHexCode_ID;
                default:
                    return ColorHexCode_EN;
            }
        }

        public string GetLikePhrase(ColorQuestionLanguage language = ColorQuestionLanguage.EN)
        {
            switch (language)
            {
                case ColorQuestionLanguage.EN:
                    return ColorLikePhrase_EN;
                case ColorQuestionLanguage.ID:
                    return ColorLikePhrase_ID;
                default:
                    return ColorLikePhrase_EN;
            }
        }

        public string GetCombinationPhrase(ColorQuestionLanguage language = ColorQuestionLanguage.EN)
        {
            switch (language)
            {
                case ColorQuestionLanguage.EN:
                    return ColorCombinationPhrase_EN;
                case ColorQuestionLanguage.ID:
                    return ColorCombinationPhrase_ID;
                default:
                    return ColorCombinationPhrase_EN;
            }
        }
    }

    public enum ColorQuestionLanguage
    {
        EN,
        ID
    }
}
