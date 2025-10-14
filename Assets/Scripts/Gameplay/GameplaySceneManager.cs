using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class GameplaySceneManager : MonoBehaviour
    {
        public static GameplaySceneManager Instance;
        private InventoryManager inventoryManager;
        [SerializeField] private ColorPicker colorPicker;
        [SerializeField] private RawImage blackScreenOverlay;
        [SerializeField] private ColorQuestionDatabase questionDatabase;
        [SerializeField] private SlimeDatabase slimeDatabase;
        [SerializeField] private TextMeshProUGUI colorQuestionText;
        [SerializeField] private Slime targetSlime;
        private ColorQuestionEntry currentColorQuestion;
        private bool isProcessingAnswer = false;

        void Start()
        {
            Instance = this;
            inventoryManager = InventoryManager.Instance;
            InitQuestion();
            colorPicker.Init();
            InitSlime();
            HideBlackScreenOverlay();
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
            int normalExpressionId = UnityEngine.Random.Range(0, slimeDatabase.NormalExpressionEntryCount);
            int happyExpressionId = UnityEngine.Random.Range(0, slimeDatabase.HappyExpressionEntryCount);
            int sadExpressionId = UnityEngine.Random.Range(0, slimeDatabase.SadExpressionEntryCount);

            Sprite bodySprite = slimeDatabase.GetBodyEntry(bodyId);
            Sprite normalExpressionSprite = slimeDatabase.GetNormalExpressionEntry(normalExpressionId);
            Sprite happyExpressionSprite = slimeDatabase.GetHappyExpressionEntry(happyExpressionId);
            Sprite sadExpressionSprite = slimeDatabase.GetSadExpressionEntry(sadExpressionId);

            targetSlime.Init(
                bodySprite,
                normalExpressionSprite,
                happyExpressionSprite,
                sadExpressionSprite
            );
        }

        public void AnswerColorQuestion(int r, int g, int b)
        {
            if (isProcessingAnswer)
                return;

            bool isChoice = currentColorQuestion.IsAnswerCorrect(
                r, g, b, GetThreshold()
            );
            StartCoroutine(ShowResult(isChoice));
        }

        public void ColorSlimeTarget(Color newColor)
        {
            targetSlime.SetColor(newColor);
        }

        IEnumerator ShowResult(bool isCorrect)
        {
            isProcessingAnswer = true;
            if (isCorrect)
            {
                IncreaseCoin();
                targetSlime.SetExpressionToHappy();
                UpdateColorQuestionText(ColorQuestionDisplayEnum.SUCCESS);
            }
            else
            {
                targetSlime.SetExpressionToSad();
                UpdateColorQuestionText(ColorQuestionDisplayEnum.FAILURE);
            }
            yield return new WaitForSeconds(3f);
            isProcessingAnswer = false;
            InitQuestion();
            InitSlime();
        }

        public void ShowBlackScreenOverlay()
        {
            blackScreenOverlay.gameObject.SetActive(true);
        }

        public void HideBlackScreenOverlay()
        {
            blackScreenOverlay.gameObject.SetActive(false);
        }

        #region COLOR_QUESTION_DISPLAY
        ColorQuestionDisplayEnum currentDisplayOption;
        private enum ColorQuestionDisplayEnum
        {
            NORMAL,
            HEX,
            LIKE_PHRASE,
            COMBINATION_PHRASE,
            SUCCESS,
            FAILURE
        }
        ColorQuestionDisplayEnum[] regularQuestionDisplayEnums = {
            ColorQuestionDisplayEnum.NORMAL, ColorQuestionDisplayEnum.HEX,
            ColorQuestionDisplayEnum.LIKE_PHRASE, ColorQuestionDisplayEnum.COMBINATION_PHRASE
        };
        private void UpdateColorQuestionText()
        {
            ColorQuestionDisplayEnum currentDisplayOption = (ColorQuestionDisplayEnum)UnityEngine.Random.Range(
                0, regularQuestionDisplayEnums.Length
            );
            this.currentDisplayOption = currentDisplayOption;
            UpdateColorQuestionText(currentDisplayOption);
        }
        private void UpdateColorQuestionText(ColorQuestionDisplayEnum displayOption)
        {
            switch (displayOption)
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
                case ColorQuestionDisplayEnum.SUCCESS:
                    colorQuestionText.text = "Yay! Warna ini sesuai permintaanku!";
                    break;
                case ColorQuestionDisplayEnum.FAILURE:
                    colorQuestionText.text = "Warna ini tidak sesuai permintaanku...";
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

        #region COIN
        private void IncreaseCoin()
        {
            int coinIncreaseValue = 5;
            switch (currentDisplayOption)
            {
                case ColorQuestionDisplayEnum.HEX:
                    coinIncreaseValue = 15;
                    break;
                case ColorQuestionDisplayEnum.LIKE_PHRASE:
                    coinIncreaseValue = 10;
                    break;
                case ColorQuestionDisplayEnum.COMBINATION_PHRASE:
                    coinIncreaseValue = 10;
                    break;
            }
            inventoryManager.AddCoin(coinIncreaseValue);
        }
        #endregion
    }
}
