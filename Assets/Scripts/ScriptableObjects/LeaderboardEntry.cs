using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "LeaderboardEntry", menuName = "PlayerData/LeaderboardEntry")]
    public class LeaderboardEntry : ScriptableObject
    {
        public string SaveId;
        public List<LeaderboardRowEntry> rows = new List<LeaderboardRowEntry>();
        private const int MaxEntries = 10;

        public void SubmitScore(int score, int createdAt)
        {
            rows.Add(new LeaderboardRowEntry(score, createdAt));
            rows.Sort((a, b) => b.score.CompareTo(a.score));
            if (rows.Count > MaxEntries)
                rows.RemoveRange(MaxEntries, rows.Count - MaxEntries);
            SaveData();
        }

        public void SaveData()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(SaveId, json);
            PlayerPrefs.Save();
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey(SaveId))
            {
                string json = PlayerPrefs.GetString(SaveId);
                JsonUtility.FromJsonOverwrite(json, this);
            }
        }
    }

    [System.Serializable]
    public class LeaderboardRowEntry
    {
        public int score;
        public int createdAt;

        public LeaderboardRowEntry(int score, int createdAt)
        {
            this.score = score;
            this.createdAt = createdAt;
        }

        public string GetScoreText()
        {
            return score.ToString();
        }

        public string GetCreatedAtText()
        {
            System.DateTime dateTime = System.DateTimeOffset.FromUnixTimeSeconds(createdAt).DateTime;
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
