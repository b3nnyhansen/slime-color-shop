using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Encyclopedia
{
    public class EncyclopediaSceneManager : BaseSceneManager
    {
        [SerializeField] private ColorQuestionDatabase questionDatabase;
        [SerializeField] private GameButton encyclopediaItemButtonObject;
        [SerializeField] private RectTransform scrollViewContentTransform;
        [SerializeField] private EncyclopediaQuestionItemViewer itemViewer;

        void Start()
        {
            InitScene();
        }

        private void InitScene()
        {
            itemViewer.Init();
            InitEncyclopediaItemButtons();
        }

        private void InitEncyclopediaItemButtons()
        {
            foreach(ColorQuestionEntry entry in questionDatabase.Entries)
            {
                GameButton newButton = Instantiate(encyclopediaItemButtonObject, scrollViewContentTransform);
                int displayState = questionDatabase.LoadData(entry);
                newButton.Init(
                    delegate {
                        itemViewer.ShowQuestionItem(entry, displayState);
                    }
                );
                
                string buttonName = (displayState & 1) > 0 ? entry.ColorName : "???";
                newButton.SetButtonText(buttonName);
                newButton.SetButtonColor(entry);
                newButton.SetButtonFontSize(60f);
            }
        }
    }
}
