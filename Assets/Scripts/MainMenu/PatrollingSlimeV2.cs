using UnityEngine;
using SlimeColorShop.Gameplay;
using System.Collections;
using Spine.Unity;

namespace SlimeColorShop.MainMenu
{
    public class PatrollingSlimeV2 : Slime
    {
        [SerializeField] private SkeletonGraphic skeletonGraphic;
        private RectTransform parentRectTransform;
        private RectTransform rectTransformComponent;

        public void Init()
        {
            parentRectTransform = transform.parent.GetComponent<RectTransform>();
            rectTransformComponent = GetComponent<RectTransform>();

            skeletonGraphic.AnimationState.SetAnimation(0, "animation", true);

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
