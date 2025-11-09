using System.Collections.Generic;
using SlimeColorShop.Data;
using UnityEngine;

namespace SlimeColorShop.Decor
{
    public class DecorSceneManager : BaseSceneManager
    {
        [SerializeField] private GameButton returnButton;
        [SerializeField] private List<Decoration> decorations;
        [SerializeField] private DecorationSelectionManager decorationSelectionManager;

        void Start()
        {
            foreach (Decoration decoration in decorations)
                decoration.Init(
                    delegate
                    {
                        decorationSelectionManager.ShowCanvasGroup();
                    }
                );
            decorationSelectionManager.Init();
        }

        private void InitSceneParameters()
        {
            
        }
    }
}
