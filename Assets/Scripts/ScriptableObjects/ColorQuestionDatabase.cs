using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ColorQuestionDatabase", menuName = "Database/ColorQuestionDatabase")]
    public class ColorQuestionDatabase : ScriptableObject
    {
        public List<ColorQuestionEntry> Entries;

        public int EntryCount
        {
            get { return Entries.Count; }
        }

        public ColorQuestionEntry GetEntry(int id)
        {
            if (id < 0 || id >= EntryCount)
                id = 0;
            return Entries[id];
        }

        private string GetSaveKey(int id)
        {
            string saveKey = string.Format("CQ_ENC_STATE_{0:0000}", id);
            return saveKey;
        }

        public void SaveData(int id, int encyclopediaState)
        {
            
            PlayerPrefs.SetInt(GetSaveKey(id), encyclopediaState);
        }

        public int LoadData(int id)
        {
            return PlayerPrefs.GetInt(GetSaveKey(id), 0);
        }

        public int GetEntryId(ColorQuestionEntry entry)
        {
            return Entries.IndexOf(entry);
        }

        public int LoadData(ColorQuestionEntry entry)
        {
            int id = GetEntryId(entry);
            return LoadData(id);
        }
    }
}
