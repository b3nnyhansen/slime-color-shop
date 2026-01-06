using System.Collections;
using UnityEngine;

namespace SlimeColorShop.Gameplay
{
    public class BonusDisplay : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        [SerializeField] private RectTransform progressBarRectTransform;
        [SerializeField] private StarEffect starEffectObject;
        private const float MAX_WIDTH = 63f;
        private const float MIN_HEIGHT = 33f;
        private const float MAX_HEIGHT = 723f;
        private const int MAX_POINT = 5;
        private int bonusPoint = 0;
        private float targetHeight;
        private bool isChangingSize = false;
        private bool isSparkling = false;

        public void Init()
        {
            progressBarRectTransform.sizeDelta = new Vector2(MAX_WIDTH, MIN_HEIGHT);
        }

        public void AddBonusPoint(int add)
        {
            bonusPoint += add;
            
            if (bonusPoint > MAX_POINT)
                bonusPoint = MAX_POINT;

            if (bonusPoint < 0)
                bonusPoint = 0;

            SetTargetHeight();
            if (!isChangingSize)
                StartCoroutine( TranslateIndicatorBarOverTime() );
            
            if(!isSparkling && IsBonusTakingEffect())
            {
                isSparkling = true;
                StartCoroutine( Sparkle() );
            }
            else
            {
                isSparkling = false;
            }
        }

        private void SetTargetHeight()
        {
            targetHeight = MIN_HEIGHT + (MAX_HEIGHT - MIN_HEIGHT) * bonusPoint / MAX_POINT;
        }

        IEnumerator TranslateIndicatorBarOverTime()
        {
            isChangingSize = true;
            float difference = targetHeight - progressBarRectTransform.sizeDelta.y;
            while (Mathf.Abs(difference) >= 1f)
            {
                float sign = Mathf.Sign(difference);
                progressBarRectTransform.sizeDelta += Vector2.up * sign;
                yield return new WaitForFixedUpdate();
                difference = targetHeight - progressBarRectTransform.sizeDelta.y;
            }
            isChangingSize = false;
        }

        IEnumerator Sparkle()
        {
            while (isSparkling)
            {
                Vector2 position = Utility.GetRandomPositionFromCenterBottomAnchoredRectTransform(progressBarRectTransform);
                StarEffect instance = Instantiate(starEffectObject, transform);
                instance.Init(position);
                yield return new WaitForSeconds(.25f);
            }
        }

        public bool IsBonusTakingEffect()
        {
            return bonusPoint == MAX_POINT;
        }
    }
}
