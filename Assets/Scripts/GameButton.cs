using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop
{
    public class GameButton : MonoBehaviour
    {
        protected Action onClickAction;
        protected Button buttonComponent;

        public virtual void Init(Action onClickAction = null)
        {
            this.onClickAction = onClickAction;
            buttonComponent = gameObject.GetComponent<Button>();
            SetOnClickAction();
        }

        protected virtual void SetOnClickAction()
        {
            buttonComponent.onClick.AddListener(
                delegate
                {
                    onClickAction?.Invoke();
                }
            );
        }
    }
}
