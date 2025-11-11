using System;
using SlimeColorShop.Data;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeColorShop.Decor
{
    public class DecorationSelectionManager : BaseFormHandler
    {
        [SerializeField] private DecorationSelectButton removeDecorButton;
        [SerializeField] private DecorationSelectButton decorationSelectButtonObject;
        [SerializeField] private RectTransform selectionTransform;
        private DecorSceneManager decorSceneManager;

        public void Init(DecorSceneManager decorSceneManager, ShopItemDatabase shopItemDatabase)
        {
            this.decorSceneManager = decorSceneManager;
            InitSelectButtons(shopItemDatabase);
            base.Init();
        }

        private void InitSelectButtons(ShopItemDatabase shopItemDatabase)
        {
            removeDecorButton.Init(-1, null, ChangeDecoration);
            for (int i = 0; i < shopItemDatabase.EntryCount; i++)
            {
                ShopItemEntry shopItemEntry = shopItemDatabase.GetEntry(i);
                if (!shopItemEntry.IsBought())
                    continue;
                DecorationSelectButton instance = Instantiate(decorationSelectButtonObject, selectionTransform);
                instance.Init(i, shopItemEntry, ChangeDecoration);
            }
        }
        
        private void ChangeDecoration(int shopItemEntryId)
        {
            decorSceneManager.SetSelectedShopItemEntryId(shopItemEntryId);
            decorSceneManager.SaveDecoration();
        }
    }
}
