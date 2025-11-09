using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "DecorationDatabase", menuName = "Database/DecorationDatabase")]
    public class DecorationDatabase : ScriptableObject
    {
        public List<DecorationEntry> Entries;

        public int EntryCount
        {
            get { return Entries.Count; }
        }

        public DecorationEntry GetEntry(int id)
        {
            if (id < 0 || id >= EntryCount)
                return null;
            return Entries[id];
        }
    }
}
