using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace SlimeColorShop
{
    public class EnergyManager : MonoBehaviour
    {
        private InventoryManager inventoryManager;
        [SerializeField] private TextMeshProUGUI energyValueText;
        [SerializeField] private TextMeshProUGUI energyTimeText;
        private const int timeDifferenceThreshold = 900;
        Coroutine countdownCoroutine;

        private Action onCountdownEndAction;
        public void Init(
            InventoryManager inventoryManager,
            Action onCountdownEndAction = null)
        {
            this.inventoryManager = inventoryManager;
            SetOnCountdownEndAction(onCountdownEndAction);

            ComputeTimeDifference();
            SetEnergyValueText();
            StartCoroutine(Idle());
        }

        private void ComputeTimeDifference()
        {
            long prevTimeValue = inventoryManager.LoadLastLoginData();
            long currentTimeValue = Utility.GetCurrentTimestamp();
            long timeDifference = currentTimeValue - prevTimeValue;
            if (timeDifference < timeDifferenceThreshold)
            {
                SetEnergyTimeText(timeDifference);
                return;
            }
            // int additionalEnergy = (int)(timeDifference / 60);
            SetEnergyTimeText("");
            inventoryManager.SaveEnergyData();
            inventoryManager.SaveLastLoginData(currentTimeValue);
        }

        public void StartCountdown()
        {
            countdownCoroutine = StartCoroutine(Countdown());
        }

        public void StopCountdown()
        {
            StopCoroutine(countdownCoroutine);
        }

        public void SetOnCountdownEndAction(Action onCountdownEndAction)
        {
            this.onCountdownEndAction = onCountdownEndAction;
        }

        public void SetEnergyValueText()
        {
            string text = inventoryManager.LoadEnergyData().ToString();
            SetEnergyValueText(text);
        }

        public void SetEnergyValueText(string text)
        {
            energyValueText.text = text;
        }

        public void SetEnergyTimeText(long timeDifference)
        {
            long remainingTime = timeDifferenceThreshold - timeDifference;
            long minutes = remainingTime / 60;
            long seconds = remainingTime % 60;
            string text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
            SetEnergyTimeText(text);
        }

        public void SetEnergyTimeText(string text)
        {
            energyTimeText.text = text;
        }

        IEnumerator Countdown()
        {
            int energyValue = inventoryManager.LoadEnergyData();
            while (energyValue > 0)
            {
                yield return new WaitForSeconds(1f);
                inventoryManager.AddEnergyValue(-1);
                energyValue = inventoryManager.LoadEnergyData();
            }
            onCountdownEndAction?.Invoke();
            yield return new WaitForFixedUpdate();
        }

        IEnumerator Idle()
        {
            while(true)
            {
                ComputeTimeDifference();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}