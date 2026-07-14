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

        public string GetColorName(GameLanguageEnum language = GameLanguageEnum.EN)
        {
            switch (language)
            {
                case GameLanguageEnum.EN:
                    return ColorName_EN;
                case GameLanguageEnum.ID:
                    return ColorName_ID;
                default:
                    return ColorName_EN;
            }
        }

        public string GetColorNameEN()
        {
            return ColorName_EN;
        }

        public string GetColorNameID()
        {
            return ColorName_ID;
        }

        public string GetColorHexCode(GameLanguageEnum language = GameLanguageEnum.EN)
        {
            switch (language)
            {
                case GameLanguageEnum.EN:
                    return ColorHexCode_EN;
                case GameLanguageEnum.ID:
                    return ColorHexCode_ID;
                default:
                    return ColorHexCode_EN;
            }
        }

        public string GetLikePhrase(GameLanguageEnum language = GameLanguageEnum.EN)
        {
            switch (language)
            {
                case GameLanguageEnum.EN:
                    return ColorLikePhrase_EN;
                case GameLanguageEnum.ID:
                    return ColorLikePhrase_ID;
                default:
                    return ColorLikePhrase_EN;
            }
        }

        public string GetCombinationPhrase(GameLanguageEnum language = GameLanguageEnum.EN)
        {
            int r = Mathf.RoundToInt(R * 100f / 255f),
                g = Mathf.RoundToInt(G * 100f / 255f),
                b = Mathf.RoundToInt(B * 100f / 255f);
            switch (language)
            {
                case GameLanguageEnum.EN:
                    return string.Format("{0}% red, {1}% green, {2}% blue", r, g, b);
                case GameLanguageEnum.ID:
                    return string.Format("{0}% merah, {1}% hijau, {2}% biru", r, g, b);
                default:
                    return string.Format("{0}% red, {1}% green, {2}% blue", r, g, b);
            }
        }
    }
}
