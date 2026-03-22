using System;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class SlimeV2 : Slime
    {
        [SerializeField] private SkeletonGraphic skeletonGraphic;

        public void Init(
            Sprite normalExpressionSprite,
            Sprite happyExpressionSprite,
            Sprite sadExpressionSprite,
            SkeletonDataAsset skeletonDataAsset = null
        )
        {
            base.Init(null, normalExpressionSprite, happyExpressionSprite, sadExpressionSprite);
            
            if (skeletonDataAsset != null)
                skeletonGraphic.skeletonDataAsset = skeletonDataAsset;

            skeletonGraphic.initialSkinName = "default";
            skeletonGraphic.startingAnimation = null;
            skeletonGraphic.Initialize(true);
            skeletonGraphic.SetMaterialDirty();
            
            skeletonGraphic.AnimationState.SetAnimation(0, "animation", true);
        }

        public override void SetColor(Color newColor)
        {
            skeletonGraphic.color = newColor;
        }
    }
}
