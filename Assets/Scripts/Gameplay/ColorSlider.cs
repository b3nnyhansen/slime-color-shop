using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

namespace SlimeColorShop.Gameplay
{
    public class ColorSlider : MonoBehaviour
    {
        [SerializeField] private TMP_InputField colorValueText;
        [SerializeField] private Slider colorSlider;
        private ColorPicker colorPicker;

        private bool isUpdating = false;
        private Action onEndUpdateValueAction;

        public void Init(
            ColorPicker colorPicker,
            Color color,
            Action onEndUpdateValueAction
        )
        {
            this.colorPicker = colorPicker;
            SetSliderColor(color);
            this.onEndUpdateValueAction = onEndUpdateValueAction;

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

            colorSlider.value = 255f;
        }

        private void OnSliderValueChanged()
        {
            SetIsUpdating(true);
            colorValueText.text = ((int)colorSlider.value).ToString();
            SetIsUpdating(false);
        }

        private void OnTextValueChanged()
        {
            SetIsUpdating(true);
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
            SetIsUpdating(false);
        }

        public float GetSliderValue()
        {
            return colorSlider.value / 255f;
        }

        public bool IsUpdating()
        {
            return isUpdating;
        }

        public void SetSliderColor(Color color)
        {
            Image[] images = colorSlider.GetComponentsInChildren<Image>(true);
            foreach (Image img in images)
            {
                img.color *= color;
            }
        }

        public void SetIsUpdating(bool isUpdating)
        {
            if (!isUpdating)
                onEndUpdateValueAction?.Invoke();
            this.isUpdating = isUpdating;
        }
    }
}
