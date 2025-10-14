using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "LongDataEntry", menuName = "PlayerData/LongDataEntry")]
    public class LongDataEntry : PlayerDataEntry
    {
        public string DefaultValue;

        public override void SaveData(object data)
        {
            PlayerPrefs.SetString(SaveId, data.ToString());
        }

        public override object LoadData()
        {
            string temp = PlayerPrefs.GetString(SaveId, DefaultValue);
            return long.Parse(temp);
        }
    }
}