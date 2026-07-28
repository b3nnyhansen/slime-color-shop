using System.Collections.Generic;
using UnityEngine;
using SlimeColorShop.Data;

namespace SlimeColorShop.MainMenu
{
    public class LeaderboardFormHandler : BaseFormHandler
    {
        [SerializeField] private Transform rowContainer;
        [SerializeField] private LeaderboardFormRow leaderboardFormRowPrefab;
        private LeaderboardEntry leaderboardEntry;
        private List<LeaderboardFormRow> leaderboardFormRows;
        private int maxRowCount;

        public override void Init()
        {
            InitLeaderboardRows();
            base.Init();
        }

        private void InitLeaderboardRows()
        {
            leaderboardEntry = InventoryManager.Instance.GetLeaderboardEntry();
            maxRowCount = leaderboardEntry.MaxEntriesCount;

            leaderboardFormRows = new List<LeaderboardFormRow>();
            for (int i = 0; i < maxRowCount; i++)
            {
                LeaderboardFormRow instance = Instantiate(leaderboardFormRowPrefab, rowContainer);
                leaderboardFormRows.Add(instance);
            }
        }

        private void LoadLeaderboardData()
        {
            for (int i = 0; i < maxRowCount; i++)
            {
                if (i < leaderboardEntry.CurrentEntriesCount)
                {
                    LeaderboardRowEntry row = leaderboardEntry.Rows[i];
                    string numberText = (i+1).ToString();
                    string scoreText = row.GetScoreText();
                    leaderboardFormRows[i].Init(numberText, scoreText);
                }
                else
                {
                    leaderboardFormRows[i].Init("-", "-");
                }
            }
        }

        public void Show()
        {
            LoadLeaderboardData();
            ShowCanvasGroup();
        }

        public void Hide()
        {
            HideCanvasGroup();
        }
    }
}