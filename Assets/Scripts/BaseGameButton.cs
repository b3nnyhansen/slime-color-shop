using System;
using UnityEngine;
using UnityEngine.UI;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public abstract class BaseGameButton : MonoBehaviour
    {
        protected Action onClickAction;
        protected Image imageComponent;
        protected Button buttonComponent;

        public virtual void Init(Action onClickAction = null)
        {
            this.onClickAction = onClickAction;
            imageComponent = gameObject.GetComponent<Image>();
            buttonComponent = gameObject.GetComponent<Button>();

            SetOnClickAction();
        }

        protected virtual void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    onClickAction?.Invoke();
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
        }
    }
}
