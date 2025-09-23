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
    }
}
