using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class GameplaySceneManager : MonoBehaviour
    {
        public static GameplaySceneManager Instance;
        [SerializeField] private ColorPicker colorPicker;
        [SerializeField] private ColorQuestionDatabase questionDatabase;
        [SerializeField] private SlimeDatabase slimeDatabase;
        [SerializeField] private TextMeshProUGUI colorQuestionText;
        [SerializeField] private Slime targetSlime;
        private ColorQuestionEntry currentColorQuestion;

        void Start()
        {
            Instance = this;
            InitQuestion();
            colorPicker.Init();
            InitSlime();
        }

        private void InitQuestion()
        {
            int id = UnityEngine.Random.Range(0, questionDatabase.EntryCount);
            currentColorQuestion = questionDatabase.GetEntry(id);
            UpdateColorQuestionText();
        }
        private void InitSlime()
        {
            int bodyId = UnityEngine.Random.Range(0, slimeDatabase.BodyEntryCount);
            int expressionId = UnityEngine.Random.Range(0, slimeDatabase.ExpressionEntryCount);

            Sprite bodySprite = slimeDatabase.GetBodyEntry(bodyId);
            Sprite expressionSprite = slimeDatabase.GetExpressionEntry(expressionId);

            targetSlime.SetAppearance(bodySprite, expressionSprite);
        }

        public void AnswerColorQuestion(int r, int g, int b)
        {
            if (
                currentColorQuestion.IsAnswerCorrect(
                    r, g, b, GetThreshold()
                )
            )
            {
                InitQuestion();
                InitSlime();
            }
        }

        public void ColorSlimeTarget(Color newColor)
        {
            targetSlime.SetColor(newColor);
        }

        #region COLOR_QUESTION_DISPLAY
        ColorQuestionDisplayEnum currentDisplayOption;
        private enum ColorQuestionDisplayEnum
        {
            NORMAL,
            HEX,
            LIKE_PHRASE,
            COMBINATION_PHRASE
        }
        private void UpdateColorQuestionText()
        {
            ColorQuestionDisplayEnum currentDisplayOption = Utility
                .GetRandomEnumValue<ColorQuestionDisplayEnum>();
            this.currentDisplayOption = currentDisplayOption;

            switch (currentDisplayOption)
            {
                case ColorQuestionDisplayEnum.HEX:
                    colorQuestionText.text = currentColorQuestion.ColorHexCode;
                    break;
                case ColorQuestionDisplayEnum.LIKE_PHRASE:
                    colorQuestionText.text = currentColorQuestion.ColorLikePhrase;
                    break;
                case ColorQuestionDisplayEnum.COMBINATION_PHRASE:
                    colorQuestionText.text = currentColorQuestion.ColorLikePhrase;
                    break;
                default:
                    colorQuestionText.text = currentColorQuestion.ColorName;
                    break;
            }
        }
        private int GetThreshold()
        {
            int threshold;
            switch (currentDisplayOption)
            {
                case ColorQuestionDisplayEnum.HEX:
                    threshold = 5;
                    break;
                case ColorQuestionDisplayEnum.LIKE_PHRASE:
                    threshold = 15;
                    break;
                case ColorQuestionDisplayEnum.COMBINATION_PHRASE:
                    threshold = 10;
                    break;
                default:
                    threshold = 10;
                    break;
            }
            return threshold;
        }
        #endregion
    }
}
