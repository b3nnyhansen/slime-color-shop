using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop
{
    public abstract class BaseFormHandler : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup canvasGroupComponent;
        [SerializeField] protected Button outerScreenButton;

        public virtual void Init()
        {
            outerScreenButton.onClick.AddListener(
                delegate
                {
                    HideCanvasGroup();
                }
            );
            HideCanvasGroup();
        }

        public void HideCanvasGroup()
        {
            Utility.HideCanvasGroup(canvasGroupComponent);
        }

        public void ShowCanvasGroup()
        {
            Utility.ShowCanvasGroup(canvasGroupComponent);
        }
    }
}