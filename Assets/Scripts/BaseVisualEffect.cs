using System.Collections;
using UnityEngine;

namespace SlimeColorShop
{
    public abstract class BaseVisualEffect : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroupComponent;
        protected float fadingSpeed;

        public virtual void Init(Vector2 position, float fadingSpeed = 1f)
        {
            SetFadingSpeed(fadingSpeed);

            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;

            StartCoroutine( Fade() );
        }

        protected virtual IEnumerator Fade()
        {
            float delta = -.05f * fadingSpeed;
            while (canvasGroupComponent.alpha > 0)
            {
                canvasGroupComponent.alpha += delta;
                yield return new WaitForFixedUpdate();
            }
            Destroy(gameObject);
        }

        public void SetFadingSpeed(float fadingSpeed)
        {
            this.fadingSpeed = fadingSpeed;
        }
    }
}