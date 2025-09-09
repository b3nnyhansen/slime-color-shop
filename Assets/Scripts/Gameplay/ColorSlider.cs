using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimeColorShop.Gameplay
{
    public class ColorSlider : MonoBehaviour
    {
        [SerializeField] private TMP_InputField colorValueText;
        [SerializeField] private Slider colorSlider;
        private ColorPicker colorPicker;
        private bool isUpdating = false;

        public void Init(ColorPicker colorPicker, Color color)
        {
            this.colorPicker = colorPicker;
            SetSliderColor(color);

            colorSlider.onValueChanged.AddListener(
                delegate
                {
                    if (!isUpdating)
                        OnSliderValueChanged();
                }
            );

            colorValueText.onValueChanged.AddListener(
                delegate
                {
                    if (!isUpdating)
                        OnTextValueChanged();
                }
            );
        }

        private void OnSliderValueChanged()
        {
            isUpdating = true;
            colorValueText.text = ((int)colorSlider.value).ToString();
            colorPicker.UpdateTargetColor();
            isUpdating = false;
        }

        private void OnTextValueChanged()
        {
            isUpdating = true;
            if (int.TryParse(colorValueText.text, out int result))
            {
                if (result > 255)
                {
                    result = 255;
                    colorValueText.text = "255";
                }
                if (result < 0)
                {
                    result = 0;
                    colorValueText.text = "0";
                }
                colorSlider.value = result;
            }
            else
            {
                colorSlider.value = 0;
                colorValueText.text = "0";
            }
            colorPicker.UpdateTargetColor();
            isUpdating = false;
        }

        public float GetSliderValue()
        {
            return colorSlider.value / 255f;
        }

        public void SetSliderColor(Color color)
        {
            // ColorBlock cb = colorSlider.colors;
            // cb.normalColor = color;
            // cb.highlightedColor = color;
            // cb.pressedColor = color;
            // cb.selectedColor = color;
            // cb.disabledColor = color;
            // colorSlider.colors = cb;

            Image[] images = colorSlider.GetComponentsInChildren<Image>(true);
            foreach (Image img in images)
            {
                img.color *= color;
            }
        }
    }
}
