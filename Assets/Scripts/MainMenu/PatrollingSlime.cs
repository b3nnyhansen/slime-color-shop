using UnityEngine;
using SlimeColorShop.Gameplay;
using System.Collections;

namespace SlimeColorShop.MainMenu
{
    public class PatrollingSlime : Slime
    {
        private RectTransform parentRectTransform;
        private RectTransform rectTransformComponent;

        public override void Init(
            Sprite bodySprite,
            Sprite normalExpressionSprite,
            Sprite happyExpressionSprite,
            Sprite sadExpressionSprite
        )
        {
            base.Init(bodySprite, normalExpressionSprite, happyExpressionSprite, sadExpressionSprite);

            parentRectTransform = transform.parent.GetComponent<RectTransform>();
            rectTransformComponent = GetComponent<RectTransform>();

            StartCoroutine(Patrol());
        }

        IEnumerator Patrol()
        {
            Vector2 boundary = parentRectTransform.sizeDelta; 

            while(true)
            {
                Vector2 nextPosition = new Vector2(
                    UnityEngine.Random.Range(-boundary.x / 2, boundary.x / 2),
                    UnityEngine.Random.Range(-boundary.y / 2, boundary.y / 2)
                );
                float distance = Vector2.Distance(rectTransformComponent.anchoredPosition, nextPosition);
                Vector2 direction = (nextPosition - rectTransformComponent.anchoredPosition).normalized;
                while(distance > 20f)
                {
                    rectTransformComponent.anchoredPosition += direction * Time.fixedDeltaTime * 20f;
                    yield return new WaitForFixedUpdate();
                    distance = Vector2.Distance(rectTransformComponent.anchoredPosition, nextPosition);
                    direction = (nextPosition - rectTransformComponent.anchoredPosition).normalized;
                }
            }
        }
    }
}
