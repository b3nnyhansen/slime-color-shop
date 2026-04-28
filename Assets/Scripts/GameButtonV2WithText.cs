using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;

namespace SlimeColorShop
{
    public class GameButtonV2WithText : MonoBehaviour
    {
        protected Action onClickAction;
        [SerializeField] protected TextMeshProUGUI textComponent;
        protected Button buttonComponent;
        protected bool isOn;
        [SerializeField] protected String onText;
        [SerializeField] protected String offText;

        public virtual void Init(bool isOn = true, Action onClickAction = null)
        {
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
            textComponent.text = isOn ? onText : offText;
        }
    }
}
