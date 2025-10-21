using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SlimeColorShop.Data;

namespace SlimeColorShop
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private EnergyManager energyManager;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private IntegerDataEntry energyData;
        [SerializeField] private PlayerDataEntry coinData;
        [SerializeField] private PlayerDataEntry lastLoginData;
        private const int maximumEnergy = 60;

        protected override void Awake()
        {
            base.Awake();
            SetCoinText();
            energyManager.Init(Instance);
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

        public void AddCoin(int value)
        {
            int curValue = LoadCoinData();
            SaveCoinData(curValue + value);
            SetCoinText();
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
        #endregion

        public bool IsEnergyEmpty()
        {
            return LoadCoinData() < 1;
        }

        public bool IsCostLessThanCoin(int cost)
        {
            return (cost - LoadCoinData()) < 1;
        }
    }
}
