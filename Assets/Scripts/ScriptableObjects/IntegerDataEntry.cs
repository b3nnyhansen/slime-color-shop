using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "IntegerDataEntry", menuName = "PlayerData/IntegerDataEntry")]
    public class IntegerDataEntry : PlayerDataEntry
    {
        public int DefaultValue;

        public override void SaveData(object data)
        {
            PlayerPrefs.SetInt(SaveId, (int)data);
        }

        public override object LoadData()
        {
            return PlayerPrefs.GetInt(SaveId, DefaultValue);
        }
    }
}