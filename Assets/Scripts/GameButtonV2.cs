using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public class GameButtonV2 : MonoBehaviour
    {
        protected Action onClickAction;
        protected Image imageComponent;
        protected Button buttonComponent;
        protected bool isOn;
        [SerializeField] protected Sprite onSprite;
        [SerializeField] protected Sprite offSprite;

        public virtual void Init(bool isOn = true, Action onClickAction = null)
        {
            imageComponent = gameObject.GetComponent<Image>();
            buttonComponent = gameObject.GetComponent<Button>();

            SetIsOn(isOn);
            this.onClickAction = onClickAction;
            SetOnClickAction();
        }

        protected virtual void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    onClickAction?.Invoke();
                    SetIsOn(!isOn);
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
        }
        
        public virtual void SetIsOn(bool isOn)
        {
            this.isOn = isOn;
            SetImageComponentSprite();
        }

        public virtual void SetImageComponentSprite()
        {
            imageComponent.sprite = isOn ? onSprite : offSprite;
        }
    }
}
