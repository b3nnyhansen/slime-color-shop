using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "SlimeDatabase", menuName = "Database/SlimeDatabase")]
    public class SlimeDatabase : ScriptableObject
    {
        public List<SlimeBodyEntry> BodyEntries;
        public List<SlimeExpressionEntry> ExpressionEntries;

        public int BodyEntryCount
        {
            get { return BodyEntries.Count; }
        }
        public int ExpressionEntryCount
        {
            get { return ExpressionEntries.Count; }
        }

        public Sprite GetBodyEntry(int id)
        {
            if (id < 0 || id >= BodyEntryCount)
                id = 0;
            return BodyEntries[id].Sprite;
        }
        public Sprite GetExpressionEntry(int id)
        {
            if (id < 0 || id >= ExpressionEntryCount)
                id = 0;
            return ExpressionEntries[id].Sprite;
        }
    }
}
