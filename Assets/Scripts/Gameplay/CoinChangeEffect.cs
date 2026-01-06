using UnityEngine;
using TMPro;

namespace SlimeColorShop
{
    public class CoinChangeEffect : BaseVisualEffect
    {
        [SerializeField] private TextMeshProUGUI textComponent;

        public void Init(Vector2 position, int change)
        {
            if (change < 0)
            {
                textComponent.color = Color.red;
                textComponent.text = string.Format("-{0}", change.ToString());
            }
            else
            {
                textComponent.color = Color.green;
                textComponent.text = string.Format("+{0}", change.ToString());
            }

            base.Init(position, 0.25f);
        }
    }
}