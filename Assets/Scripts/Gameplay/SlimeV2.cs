using System;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class SlimeV2 : Slime
    {
        [SerializeField] private SkeletonGraphic skeletonGraphic_Slime;
        [SerializeField] private SkeletonGraphic skeletonGraphic_Expression;

        private SkeletonDataAsset skeletonDataAsset_ExpressionNormal;
        private SkeletonDataAsset skeletonDataAsset_ExpressionHappy;
        private SkeletonDataAsset skeletonDataAsset_ExpressionSad;

        public void Init(
            SkeletonDataAsset skeletonDataAsset_Slime = null,
            SkeletonDataAsset skeletonDataAsset_ExpressionNormal = null,
            SkeletonDataAsset skeletonDataAsset_ExpressionHappy = null,
            SkeletonDataAsset skeletonDataAsset_ExpressionSad = null
        )
        {
            this.skeletonDataAsset_ExpressionNormal = skeletonDataAsset_ExpressionNormal;
            this.skeletonDataAsset_ExpressionHappy = skeletonDataAsset_ExpressionHappy;
            this.skeletonDataAsset_ExpressionSad = skeletonDataAsset_ExpressionSad;

            InitializeSkeletonGraphic(skeletonGraphic_Slime, skeletonDataAsset_Slime);
            SetAppearanceV2(skeletonDataAsset_ExpressionNormal);
        }

        private void InitializeSkeletonGraphic(SkeletonGraphic skeletonGraphic, SkeletonDataAsset skeletonDataAsset)
        {
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
            skeletonGraphic_Slime.color = newColor;
        }

        public void SetAppearanceV2(SkeletonDataAsset skeletonDataAsset)
        {
            SetExpressionV2(skeletonDataAsset);
            SetColor(Color.white);
        }

        public void SetExpressionV2(SkeletonDataAsset skeletonDataAsset)
        {
            InitializeSkeletonGraphic(skeletonGraphic_Expression, skeletonDataAsset);
        }

        public void SetExpressionToHappyV2()
        {
            SetExpressionV2(skeletonDataAsset_ExpressionHappy);
        }

        public void SetExpressionToSadV2()
        {
            SetExpressionV2(skeletonDataAsset_ExpressionSad);
        }
    }
}
