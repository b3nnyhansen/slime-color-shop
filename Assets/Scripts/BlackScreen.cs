using System;
using System.Collections;
using UnityEngine;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public class BlackScreen : Singleton<BlackScreen>
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        
        protected override void DoAwakeEvent()
        {
            canvasGroupComponent.alpha = 0f;
            canvasGroupComponent.blocksRaycasts = false;
        }

        private float duration;
        private Action onPreTransitionAction;
        private Action onPostTransitionAction;

        public void DoFadeOut(
            float duration = 1f,
            Action onPreTransitionAction = null,
            Action onPostTransitionAction = null
        )
        {
            this.duration = duration;
            this.onPreTransitionAction = onPreTransitionAction;
            this.onPostTransitionAction = onPostTransitionAction;
            
            StartCoroutine(FadeOut());
        }

        public void DoFadeIn(
            float duration = 1f,
            Action onPreTransitionAction = null,
            Action onPostTransitionAction = null
        )
        {
            this.duration = duration;
            this.onPreTransitionAction = onPreTransitionAction;
            this.onPostTransitionAction = onPostTransitionAction;
            
            StartCoroutine(FadeIn());
        }

        IEnumerator FadeOut()
        {
            onPreTransitionAction?.Invoke();
            float delta = Time.fixedDeltaTime / duration;
            
            canvasGroupComponent.alpha = 0f;
            canvasGroupComponent.blocksRaycasts = true;
            while (canvasGroupComponent.alpha < 1f)
            {
                canvasGroupComponent.alpha += delta;
                UniversalAudioManager.Instance.UpdateAudioVolume(1f - canvasGroupComponent.alpha);
                yield return new WaitForFixedUpdate();
            }
            canvasGroupComponent.blocksRaycasts = false;
            onPostTransitionAction?.Invoke();
        }

        IEnumerator FadeIn()
        {
            onPreTransitionAction?.Invoke();
            float delta = Time.fixedDeltaTime / duration;
            
            canvasGroupComponent.alpha = 1f;
            canvasGroupComponent.blocksRaycasts = true;
            while (canvasGroupComponent.alpha > 0f)
            {
                canvasGroupComponent.alpha -= delta;
                UniversalAudioManager.Instance.UpdateAudioVolume(canvasGroupComponent.alpha);
                yield return new WaitForFixedUpdate();
            }
            canvasGroupComponent.blocksRaycasts = false;
            onPostTransitionAction?.Invoke();
        }
    }
}
