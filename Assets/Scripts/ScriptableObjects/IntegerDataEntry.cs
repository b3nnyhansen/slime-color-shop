using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "IntegerDataEntry", menuName = "PlayerData/IntegerDataEntry")]
    public class IntegerDataEntry : PlayerDataEntry
    {
        public int DefaultValue;

        public override void SaveData(object data, bool saveImmediately = false)
        {
            PlayerPrefs.SetInt(SaveId, (int)data);
            if (saveImmediately)
                PlayerPrefs.Save();
        }

        public override object LoadData()
        {
            return PlayerPrefs.GetInt(SaveId, DefaultValue);
        }
    }
}