using System.Collections.Generic;
using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ShopItemDatabase", menuName = "Database/ShopItemDatabase")]
    public class ShopItemDatabase : ScriptableObject
    {
        public List<ShopItemEntry> Entries;

        public int EntryCount
        {
            get { return Entries.Count; }
        }

        public ShopItemEntry GetEntry(int id)
        {
            if (id < 0 || id >= EntryCount)
                return null;
            return Entries[id];
        } 
    }
}
