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

        public void SetAppearance(Sprite bodySprite, Sprite expressionSprite)
        {
            bodyImage.sprite = bodySprite;
            expressionImage.sprite = expressionSprite;
            SetColor(Color.white);
        }

        public void SetColor(Color newColor)
        {
            bodyImage.color = newColor;
        }
    }
}
