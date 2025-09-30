using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "SlimeDatabase", menuName = "Database/SlimeDatabase")]
    public class SlimeDatabase : ScriptableObject
    {
        public List<SlimeBodyEntry> BodyEntries;
        public List<SlimeExpressionEntry> NormalExpressionEntries;
        public List<SlimeExpressionEntry> HappyExpressionEntries;
        public List<SlimeExpressionEntry> SadExpressionEntries;

        public int BodyEntryCount
        {
            get { return BodyEntries.Count; }
        }
        public int NormalExpressionEntryCount
        {
            get { return NormalExpressionEntries.Count; }
        }
        public int HappyExpressionEntryCount
        {
            get { return HappyExpressionEntries.Count; }
        }
        public int SadExpressionEntryCount
        {
            get { return SadExpressionEntries.Count; }
        }

        public Sprite GetBodyEntry(int id)
        {
            if (id < 0 || id >= BodyEntryCount)
                id = 0;
            return BodyEntries[id].Sprite;
        }
        public Sprite GetNormalExpressionEntry(int id)
        {
            if (id < 0 || id >= NormalExpressionEntryCount)
                id = 0;
            return NormalExpressionEntries[id].Sprite;
        }
        public Sprite GetHappyExpressionEntry(int id)
        {
            if (id < 0 || id >= HappyExpressionEntryCount)
                id = 0;
            return HappyExpressionEntries[id].Sprite;
        }
        public Sprite GetSadExpressionEntry(int id)
        {
            if (id < 0 || id >= SadExpressionEntryCount)
                id = 0;
            return SadExpressionEntries[id].Sprite;
        }
    }
}
