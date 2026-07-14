using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "LongDataEntry", menuName = "PlayerData/LongDataEntry")]
    public class LongDataEntry : PlayerDataEntry
    {
        public string DefaultValue;

        public override void SaveData(object data, bool saveImmediately = false)
        {
            PlayerPrefs.SetString(SaveId, data.ToString());
            if (saveImmediately)
                PlayerPrefs.Save();
        }

        public override object LoadData()
        {
            string temp = PlayerPrefs.GetString(SaveId, DefaultValue);
            return long.Parse(temp);
        }
    }
}