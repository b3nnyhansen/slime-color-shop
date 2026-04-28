using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Encyclopedia
{
    public class EncyclopediaSceneManager : BaseSceneManager
    {
        [SerializeField] private ColorQuestionDatabase questionDatabase;
        [SerializeField] private EncyclopediaButton encyclopediaItemButtonObject;
        [SerializeField] private RectTransform scrollViewContentTransform;
        [SerializeField] private EncyclopediaQuestionItemViewer itemViewer;
        [SerializeField] private GameButton returnButton;

        void Start()
        {
            InitScene();
            InventoryManager.Instance.LoadBannerAd();
        }

        private void InitScene()
        {
            returnButton.Init(
                delegate
                {
                    LoadScene(SceneNameEnum.MAIN_MENU);
                }
            );
            itemViewer.Init();
            InitEncyclopediaItemButtons();
        }

        private void InitEncyclopediaItemButtons()
        {
            foreach(ColorQuestionEntry entry in questionDatabase.Entries)
            {
                GameLanguageEnum language = InventoryManager.Instance.GetGameLanguage();
                EncyclopediaButton newButton = Instantiate(encyclopediaItemButtonObject, scrollViewContentTransform);
                int displayState = questionDatabase.LoadData(entry);
                newButton.Init(
                    delegate {
                        itemViewer.ShowQuestionItem(entry, displayState);
                    }
                );
                
                newButton.SetDisplayState((displayState & 1) > 0);
                newButton.SetEnText(entry.GetColorNameEN());
                newButton.SetIdText(entry.GetColorNameID());
                newButton.SetButtonTextLanguage();
            }
        }

        public override void UpdateSceneLanguage()
        {
            returnButton.SetButtonTextLanguage();
            foreach (Transform child in scrollViewContentTransform)
            {
                EncyclopediaButton button = child.GetComponent<EncyclopediaButton>();
                if (button != null)
                    button.SetButtonTextLanguage();
            }
            itemViewer.SetTexts();
        }
    }
}
