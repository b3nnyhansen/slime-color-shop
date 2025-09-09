using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Gameplay
{
    public class ColorPicker : MonoBehaviour
    {
        [SerializeField] private ColorSlider redColorSlider;
        [SerializeField] private ColorSlider greenColorSlider;
        [SerializeField] private ColorSlider blueColorSlider;
        [SerializeField] private Button colorButton;
        [SerializeField] private Image targetImage;

        void Start()
        {
            redColorSlider.Init(this, Color.red);
            greenColorSlider.Init(this, Color.green);
            blueColorSlider.Init(this, Color.blue);

            InitButtons();
        }

        private void InitButtons()
        {
            colorButton.onClick.AddListener(
                delegate
                {
                    Color32 newColor = new Color(
                        redColorSlider.GetSliderValue(),
                        greenColorSlider.GetSliderValue(),
                        blueColorSlider.GetSliderValue()
                    );
                    targetImage.color = newColor;
                }
            );
        }

        public void UpdateTargetColor()
        {
            Color32 newColor = new Color(
                redColorSlider.GetSliderValue(),
                greenColorSlider.GetSliderValue(),
                blueColorSlider.GetSliderValue()
            );
            targetImage.color = newColor;
        }
    }
}
