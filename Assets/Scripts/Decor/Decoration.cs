using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class Decoration : GameButton
    {
        [SerializeField] private Image imageComponent;
        private DecorationEntry decorationEntry;

        public void SetImageSprite(Sprite sprite)
        {
            imageComponent.sprite = sprite;
        }

        public void SetImageSprite()
        {
            SetImageSprite(decorationEntry.DecorationSprite);
        }

        public void SetDecorationEntry(DecorationEntry decorationEntry)
        {
            this.decorationEntry = decorationEntry;
            SetImageSprite();
        }
    }
}
