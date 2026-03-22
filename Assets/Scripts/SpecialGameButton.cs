using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public class SpecialGameButton : MonoBehaviour
    {
        protected bool isOn;
        [SerializeField] protected GameButton onButtonComponent;
        [SerializeField] protected GameButton offButtonComponent;

        public virtual void Init(
            bool initialState = true,
            Action onClickAction = null
        )
        {
            SetOnClickAction(onClickAction, onClickAction);
            SetIsOn(initialState);
        }

        public virtual void Init(
            bool initialState = true,
            Action onClickOnAction = null,
            Action offClickOffAction = null
        )
        {
            SetOnClickAction(onClickOnAction, offClickOffAction);
            SetIsOn(initialState);
        }

        protected virtual void SetOnClickAction(
            Action onClickOnAction,
            Action onClickOffAction
        )
        {
            onButtonComponent.Init(
                delegate
                {
                    if (isOn)
                        return;
                    SetIsOn(true);
                    onClickOnAction?.Invoke();
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
            offButtonComponent.Init(
                delegate
                {
                    if (!isOn)
                        return;
                    SetIsOn(false);
                    onClickOffAction?.Invoke();
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
        }

        public virtual void SetIsOn(bool isOn)
        {
            this.isOn = isOn;
            SetButtonVisibility();
        }

        protected virtual void SetButtonVisibility()
        {
            if(isOn)
            {
                onButtonComponent.SetButtonVisible();
                offButtonComponent.SetButtonInvisible();
            }
            else
            {
                onButtonComponent.SetButtonInvisible();
                offButtonComponent.SetButtonVisible();
            }
        }
    }
}
