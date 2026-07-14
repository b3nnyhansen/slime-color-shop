using UnityEngine;

namespace SlimeColorShop.Data
{
    public abstract class PlayerDataEntry : ScriptableObject
    {
        public string SaveId;

        public abstract void SaveData(object data, bool saveImmediately = false);
        public abstract object LoadData();
    }
}