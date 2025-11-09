using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class DecorationSelectionManager : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroupComponent;
        [SerializeField] private Button outerScreenButton;

        public void Init()
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
