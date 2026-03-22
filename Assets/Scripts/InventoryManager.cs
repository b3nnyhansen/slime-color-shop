using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;

namespace SlimeColorShop
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private ShopItemDatabase shopItemDatabase;
        [SerializeField] private DecorationDatabase decorationDatabase;
        [SerializeField] private EnergyManager energyManager;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private IntegerDataEntry energyData;
        [SerializeField] private PlayerDataEntry coinData;
        [SerializeField] private PlayerDataEntry lastLoginData;
        [SerializeField] private PlayerDataEntry maxScoreData;
        [SerializeField] private RectTransform coinDisplayRectTransform;
        [SerializeField] private CoinChangeEffect coinChangeEffectObject;
        [SerializeField] private AudioDatabase audioDatabase;
        [SerializeField] private PlayerDataEntry bgmData;
        [SerializeField] private PlayerDataEntry sfxData;
        [SerializeField] private GameButton settingButton;
        [SerializeField] private SettingFormHandler settingFormHandler;
        
        private const int maximumEnergy = 180;
        private Vector2 coinChangePosition = new Vector2(+90, -50);

        protected override void Awake()
        {
            base.Awake();
            SetCoinText();
            energyManager.Init(Instance);
            settingFormHandler.Init();
            InitButtons();
        }

        private void InitButtons()
        {
            settingButton.Init(
                delegate
                {
                    settingFormHandler.ShowCanvasGroup();
                }
            );
        }

        public void StartEnergyCountdown()
        {
            energyManager.StartCountdown();
        }

        public void StartEnergyCountdown(Action onCountdownEndAction)
        {
            energyManager.SetOnCountdownEndAction(onCountdownEndAction);
            StartEnergyCountdown();
        }

        public void StopEnergyCountdown()
        {
            energyManager.StopCountdown();
        }

        public void AddEnergyValue(int value)
        {
            int curValue = LoadEnergyData();
            SaveEnergyData(curValue + value);
            energyManager.SetEnergyValueText();
        }

        public void AddCoin(int value, bool isUpdatingDisplay = true)
        {
            int curValue = LoadCoinData();
            SaveCoinData(curValue + value);
            if (isUpdatingDisplay)
            {
                SetCoinText();
                ShowChange(value);
            }
        }

        public ShopItemDatabase GetShopItemDatabase()
        {
            return shopItemDatabase;
        }

        public DecorationDatabase GetDecorationDatabase()
        {
            return decorationDatabase;
        }

        public void SetCoinText()
        {
            string text = LoadCoinData().ToString();
            SetCoinText(text);
        }

        public void SetCoinText(string text)
        {
            coinText.text = text;
        }

        #region SAVE_METHODS
        public void SaveEnergyData()
        {
            int value = energyData.DefaultValue;
            energyData.SaveData(value);
        }
        public void SaveEnergyData(int value)
        {
            energyData.SaveData(value);
        }
        public void SaveCoinData(int value)
        {
            coinData.SaveData(value);
        }
        public void SaveLastLoginData()
        {
            long value = Utility.GetCurrentTimestamp();
            SaveLastLoginData(value);
        }
        public void SaveLastLoginData(long value)
        {
            lastLoginData.SaveData(value);
        }

        public void SaveMaxScoreData(int value)
        {
            int prevMaxScore = LoadMaxScoreData();
            if (value > prevMaxScore)
                maxScoreData.SaveData(value);
        }

        public void ChangeBGMSetting()
        {
            bool isMuted = IsBGMMuted();
            bgmData.SaveData(isMuted ? 1 : 0);
        }

        public void ChangeSFXSetting()
        {
            bool isMuted = IsSFXMuted();
            sfxData.SaveData(isMuted ? 1 : 0);
        }
        #endregion

        #region LOAD_METHODS
        public int LoadEnergyData()
        {
            int value = (int)energyData.LoadData();
            return value < maximumEnergy ? value : maximumEnergy;
        }
        public int LoadCoinData()
        {
            return (int)coinData.LoadData();
        }
        public long LoadLastLoginData()
        {
            return (long)lastLoginData.LoadData();
        }

        public int LoadMaxScoreData()
        {
            return (int)maxScoreData.LoadData();
        }
        #endregion

        public bool IsEnergyEmpty()
        {
            return LoadEnergyData() < 1;
        }

        public bool IsCostLessThanCoin(int cost)
        {
            return (cost - LoadCoinData()) < 1;
        }

        public void ShowChange(int value)
        {
            CoinChangeEffect instance = Instantiate(coinChangeEffectObject, coinDisplayRectTransform);
            instance.Init(coinChangePosition, value);
        }

        public bool IsBGMMuted()
        {
            return bgmData.LoadData().Equals(0);
        }

        public bool IsSFXMuted()
        {
            return sfxData.LoadData().Equals(0);
        }

        public AudioClip GetAudioClip(AudioEnum audioEnum)
        {
            return audioDatabase.GetAudioClip(audioEnum);
        }
    }
}
