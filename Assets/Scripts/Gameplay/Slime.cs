using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class Slime : MonoBehaviour
    {
        [SerializeField] Image bodyImage;
        [SerializeField] Image expressionImage;
        Sprite normalExpressionSprite;
        Sprite happyExpressionSprite;
        Sprite sadExpressionSprite;

        public void Init(
            Sprite bodySprite,
            Sprite normalExpressionSprite,
            Sprite happyExpressionSprite,
            Sprite sadExpressionSprite
        )
        {
            this.normalExpressionSprite = normalExpressionSprite;
            this.happyExpressionSprite = happyExpressionSprite;
            this.sadExpressionSprite = sadExpressionSprite;

            SetAppearance(bodySprite, normalExpressionSprite);
        }

        public void SetAppearance(Sprite bodySprite, Sprite expressionSprite)
        {
            bodyImage.sprite = bodySprite;
            SetExpression(expressionSprite);
            SetColor(Color.white);
        }

        public void SetExpression(Sprite expressionSprite)
        {
            expressionImage.sprite = expressionSprite;
        }

        public void SetColor(Color newColor)
        {
            bodyImage.color = newColor;
        }

        public void SetExpressionToHappy()
        {
            SetExpression(happyExpressionSprite);
        }
        public void SetExpressionToSad()
        {
            SetExpression(sadExpressionSprite);
        }
    }
}
