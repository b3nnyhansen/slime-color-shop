using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class Slime : MonoBehaviour
    {
        [SerializeField] private Image bodyImage;
        [SerializeField] private Image expressionImage;
        private Sprite normalExpressionSprite;
        private Sprite happyExpressionSprite;
        private Sprite sadExpressionSprite;

        public virtual void Init(
            Sprite bodySprite,
            Sprite normalExpressionSprite,
            Sprite happyExpressionSprite,
            Sprite sadExpressionSprite
        )
        {
            this.normalExpressionSprite = normalExpressionSprite;
            this.happyExpressionSprite = happyExpressionSprite;
            this.sadExpressionSprite = sadExpressionSprite;

            if (bodySprite != null)
                SetAppearance(bodySprite, normalExpressionSprite);
            else
                SetAppearance(normalExpressionSprite);
        }

        public void SetAppearance(Sprite bodySprite, Sprite expressionSprite)
        {
            bodyImage.sprite = bodySprite;
            SetExpression(expressionSprite);
            SetColor(Color.white);
        }

        public void SetAppearance(Sprite expressionSprite)
        {
            SetExpression(expressionSprite);
            SetColor(Color.white);
        }

        public virtual void SetColor(Color newColor)
        {
            bodyImage.color = newColor;
        }

        public void SetExpression(Sprite expressionSprite)
        {
            expressionImage.sprite = expressionSprite;
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
