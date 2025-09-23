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
        public string ColorName;
        public string ColorHexCode;
        public string ColorLikePhrase;
        public string ColorCombinationPhrase;

        public bool IsAnswerCorrect(int r, int g, int b, int threshold = 0)
        {
            return
                Math.Abs(R - r) <= threshold &&
                Math.Abs(G - g) <= threshold &&
                Math.Abs(B - b) <= threshold;
        }
    }
}
