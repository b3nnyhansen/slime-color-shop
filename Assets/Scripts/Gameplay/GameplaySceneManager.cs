using System;
using System.Collections;
using SlimeColorShop.Data;
using SlimeColorShop.Audio;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Spine.Unity;

namespace SlimeColorShop.Gameplay
{
    [Serializable]
    public class GameplaySceneManager : BaseSceneManager
    {
        public static GameplaySceneManager Instance;
        private InventoryManager inventoryManager;
        [SerializeField] private ColorPicker colorPicker;
        [SerializeField] private ColorQuestionDatabase questionDatabase;
        [SerializeField] private SlimeDatabase slimeDatabase;
        [SerializeField] private TextMeshProUGUI colorQuestionText;
        [SerializeField] private Image colorQuestionTextV2;
        private Slime obsoleteTargetSlime;
        [SerializeField] private SlimeV2 targetSlime;
        [SerializeField] private GameplayOverlayManager gameplayOverlayManager;
        [SerializeField] private BonusDisplay bonusDisplay;
        [SerializeField] private Button pauseButton;
        [SerializeField] private SpineDatabase spineDatabase;
        private ColorQuestionEntry currentColorQuestion;
        private ColorQuestionEntryV2 currentColorQuestionV2;
        private bool isProcessingAnswer = false;
        private int score, coin;

        protected override void DoStartEvent()
        {
            base.DoStartEvent();
            
            Instance = this;
            inventoryManager = InventoryManager.Instance;
            score = 0;
            coin = 0;
            InitQuestion();
            colorPicker.Init();
            InitSlimeV2();
            gameplayOverlayManager.Init();
            bonusDisplay.Init();
            InitButtons();

            if (BlackScreen.Instance.IsBlackedOut)
            {
                BlackScreen.Instance.DoFadeIn(
                    onPostTransitionAction: delegate
                    {
                        InitScene();
                    }
                );
            }
            else
            {
                InitScene();
            }
        }

        private void InitScene()
        {
            inventoryManager.StartEnergyCountdown(
                delegate
                {
                    ShowGameOverScreen();
                }
            );
            UniversalAudioManager.Instance.PlayBGM(AudioEnum.BGM_PLAY);
        }

        private void InitQuestion()
        {
            // int id = UnityEngine.Random.Range(0, questionDatabase.EntryCount);
            // currentColorQuestion = questionDatabase.GetEntry(id);
            // UpdateColorQuestionText(id);
            InitQuestionV2();
        }

        private void InitQuestionV2()
        {
            currentColorQuestionV2 = new ColorQuestionEntryV2(
                UnityEngine.Random.Range(0, 11),
                UnityEngine.Random.Range(0, 11),
                UnityEngine.Random.Range(0, 11)
            );
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

            obsoleteTargetSlime.Init(
                bodySprite,
                normalExpressionSprite,
                happyExpressionSprite,
                sadExpressionSprite
            );
        }

        private void InitSlimeV2()
        {
            SkeletonDataAsset skeletonDataAsset_Slime = spineDatabase.GetSkeletonDataAsset_Slime();
            SkeletonDataAsset skeletonDataAsset_ExpressionNormal = spineDatabase.GetSkeletonDataAsset_ExpressionNormal();
            SkeletonDataAsset skeletonDataAsset_ExpressionHappy = spineDatabase.GetSkeletonDataAsset_ExpressionHappy();
            SkeletonDataAsset skeletonDataAsset_ExpressionSad = spineDatabase.GetSkeletonDataAsset_ExpressionSad();

            targetSlime.Init(
                skeletonDataAsset_Slime,
                skeletonDataAsset_ExpressionNormal,
                skeletonDataAsset_ExpressionHappy,
                skeletonDataAsset_ExpressionSad
            );
        }

        private void InitButtons()
        {
            pauseButton.onClick.AddListener(
                delegate
                {
                    ShowPauseScreen();
                    UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_BUTTON_CLICK);
                }
            );
        }

        public void AnswerColorQuestion(int r, int g, int b)
        {
            if (isProcessingAnswer)
                return;

            bool isChoice = IsAnswerCorrect(r, g, b);
            StartCoroutine(ShowResult(isChoice));
        }
        public bool IsAnswerCorrect(int r, int g, int b)
        {
            return currentColorQuestionV2.IsAnswerCorrect(
                r, g, b, GetThreshold()
            );
        }

        public void ColorSlimeTarget(Color newColor)
        {
            targetSlime.SetColor(newColor);
        }

        IEnumerator ShowResult(bool isCorrect)
        {
            inventoryManager.StopEnergyCountdown();
            isProcessingAnswer = true;
            int bonusPoint;
            if (isCorrect)
            {
                IncreaseCoin();
                bonusPoint = 1;
                score++;
                targetSlime.SetExpressionToHappyV2();
                UpdateColorQuestionText(ColorQuestionDisplayEnum.SUCCESS);
                UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_SUCCESS);
            }
            else
            {
                targetSlime.SetExpressionToSadV2();
                bonusPoint = -1;
                UpdateColorQuestionText(ColorQuestionDisplayEnum.FAILURE);
                UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_FAILURE);
            }
            bonusDisplay.AddBonusPoint(bonusPoint);
            colorPicker.SetDoubleCoinIndicatorActive(bonusDisplay.IsBonusTakingEffect());
            inventoryManager.SaveMaxScoreData(score);
            yield return new WaitForSeconds(3f);
            isProcessingAnswer = false;
            InitQuestion();
            InitSlimeV2();
            inventoryManager.StartEnergyCountdown();
        }

        public void LoadMainMenuScene()
        {
            inventoryManager.StopEnergyCountdown();
            UnpauseGame();
            BlackScreen.Instance.DoFadeOut(
                onPostTransitionAction: delegate
                {
                    UniversalAudioManager.Instance.StopBGMAudio();
                    LoadScene(SceneNameEnum.MAIN_MENU);
                }
            );
        }

        public void LoadGameplayScene()
        {
            InventoryManager.Instance.SaveEnergyData();
            BlackScreen.Instance.DoFadeOut(
                onPostTransitionAction: delegate
                {
                    UniversalAudioManager.Instance.StopBGMAudio();
                    LoadScene(SceneNameEnum.GAMEPLAY);
                }
            );
        }

        #region PAUSE_AND_GAME_OVER_CONTROL
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1f;
        }

        public void ShowPauseScreen()
        {
            PauseGame();
            gameplayOverlayManager.ShowPauseScreen();
        }

        public void HidePauseScreen()
        {
            UnpauseGame();
            gameplayOverlayManager.Hide();
        }

        public void ShowGameOverScreen()
        {
            gameplayOverlayManager.ShowGameOverScreen(
                score, inventoryManager.LoadMaxScoreData(), coin
            );
            inventoryManager.SubmitScoreToLeaderboard(score);
            inventoryManager.ShowInterstitial();
            UniversalAudioManager.Instance.PlaySFX(AudioEnum.SFX_TIMEUP);
        }
        #endregion

        #region COLOR_QUESTION_DISPLAY
        ColorQuestionDisplayEnum currentDisplayOption;
        private enum ColorQuestionDisplayEnum
        {
            IMAGE,
            PERCENTAGE,
            SUCCESS,
            FAILURE
        }
        ColorQuestionDisplayEnum[] regularQuestionDisplayEnums = {
            ColorQuestionDisplayEnum.IMAGE, ColorQuestionDisplayEnum.PERCENTAGE
        };
        private void UpdateColorQuestionText(int colorQuestionId = 0)
        {
            int prevSavedDisplayId = questionDatabase.LoadData(colorQuestionId);
            int displayId = UnityEngine.Random.Range(0, regularQuestionDisplayEnums.Length);
            ColorQuestionDisplayEnum currentDisplayOption = (ColorQuestionDisplayEnum) displayId;

            int nextSavedDisplayId = prevSavedDisplayId | (1 << displayId);
            if (nextSavedDisplayId > 1)
                nextSavedDisplayId += 1;
            questionDatabase.SaveData(colorQuestionId, nextSavedDisplayId);

            this.currentDisplayOption = currentDisplayOption;
            UpdateColorQuestionText(currentDisplayOption);
        }
        private void UpdateColorQuestionText(ColorQuestionDisplayEnum displayOption)
        {
            GameLanguageEnum language = inventoryManager.GetGameLanguage();
            switch (displayOption)
            {
                case ColorQuestionDisplayEnum.PERCENTAGE:
                    colorQuestionText.text = currentColorQuestionV2.GetCombinationPhrase(language);
                    colorQuestionTextV2.color = Color.clear;
                    break;
                case ColorQuestionDisplayEnum.SUCCESS:
                    colorQuestionText.text = "Yay! Warna ini sesuai permintaanku!";
                    colorQuestionTextV2.color = Color.clear;
                    break;
                case ColorQuestionDisplayEnum.FAILURE:
                    colorQuestionText.text = "Warna ini tidak sesuai permintaanku...";
                    colorQuestionTextV2.color = Color.clear;
                    break;
                default:
                    colorQuestionText.text = "";
                    colorQuestionTextV2.color = new Color(
                        currentColorQuestionV2.R / 255f,
                        currentColorQuestionV2.G / 255f,
                        currentColorQuestionV2.B / 255f
                    );
                    break;
            }
        }
        private int GetThreshold()
        {
            int threshold;
            switch (currentDisplayOption)
            {
                case ColorQuestionDisplayEnum.PERCENTAGE:
                    threshold = 31;
                    break;
                default:
                    threshold = 31;
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
                case ColorQuestionDisplayEnum.PERCENTAGE:
                    coinIncreaseValue = 10;
                    break;
            }
            if (bonusDisplay.IsBonusTakingEffect())
                coinIncreaseValue *= 2;
            coin += coinIncreaseValue;
            inventoryManager.AddCoin(coinIncreaseValue);
        }
        #endregion

        public override void UpdateSceneLanguage()
        {
            // gameplayOverlayManager.UpdateSceneLanguage();
            // bonusDisplay.UpdateSceneLanguage();
            // pauseButton.GetComponentInChildren<TextMeshProUGUI>().text = inventoryManager.IsGameLanguageEN() ? "Pause" : "Jeda";
            UpdateColorQuestionText(currentDisplayOption);
        }

        public class ColorQuestionEntryV2
        {
            private int r, g, b;
            private int rPerc, gPerc, bPerc;
            public int R { get { return r; } }
            public int G { get { return g; } }
            public int B { get { return b; } }
            public ColorQuestionEntryV2(int r, int g, int b)
            {
                this.r = r < 6 ? r * 25 : r * 25 + 3;
                this.g = g < 6 ? g * 25 : r * 25 + 3;
                this.b = b < 6 ? b * 25 : r * 25 + 3;
                rPerc = r * 10;
                gPerc = g * 10;
                bPerc = b * 10;
            }
            public bool IsAnswerCorrect(int r, int g, int b, int threshold = 0)
            {
                return
                    Math.Abs(this.r - r) <= threshold &&
                    Math.Abs(this.g - g) <= threshold &&
                    Math.Abs(this.b - b) <= threshold;
            }
            public string GetCombinationPhrase(GameLanguageEnum language = GameLanguageEnum.EN)
            {
                switch (language)
                {
                    case GameLanguageEnum.EN:
                        return string.Format("{0}% red, {1}% green, {2}% blue", rPerc, gPerc, bPerc);
                    case GameLanguageEnum.ID:
                        return string.Format("{0}% merah, {1}% hijau, {2}% biru", rPerc, gPerc, bPerc);
                    default:
                        return string.Format("{0}% red, {1}% green, {2}% blue", rPerc, gPerc, bPerc);
                }
            }
        }
    }
}
