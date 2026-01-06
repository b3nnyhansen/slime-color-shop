using UnityEngine;
using TMPro;
using System.Collections;

namespace SlimeColorShop
{
    public class ShowTextEffect : BaseVisualEffect
    {
        [SerializeField] private TextMeshProUGUI textComponent;

        public void Init(Vector2 position, string text, Color textColor)
        {
            textComponent.text = text;
            textComponent.color = textColor;
            base.Init(position, 0.25f);
            StartCoroutine( MoveUp() );
        }

        IEnumerator MoveUp()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            float delta = fadingSpeed;
            while (rectTransform.anchoredPosition.y < 2560f)
            {
                rectTransform.anchoredPosition += Vector2.up * delta;
                yield return new WaitForFixedUpdate();
            }
        }
    }
}

