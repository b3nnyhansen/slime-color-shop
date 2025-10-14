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

        private Action onCountdownEndAction;
        public void Init(
            InventoryManager inventoryManager,
            Action onCountdownEndAction = null)
        {
            this.inventoryManager = inventoryManager;
            this.onCountdownEndAction = onCountdownEndAction;

            SetEnergyValueText();
        }

        public void StartCountdown()
        {
            StartCoroutine(Countdown());
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

        IEnumerator Countdown()
        {
            // int energyValue
            // while (energyValue > 0)
            // {
            //     yield return new WaitForSeconds(1f);
            //     inventoryManager.AddEnergyValue(-1);
            // }
            onCountdownEndAction?.Invoke();
            yield return new WaitForFixedUpdate();
        }
    }
}