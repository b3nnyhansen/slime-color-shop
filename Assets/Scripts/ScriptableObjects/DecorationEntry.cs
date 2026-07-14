using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "DecorationEntry", menuName = "Data/DecorationEntry")]
    public class DecorationEntry : PlayerDataEntry
    {
        public override void SaveData(object data, bool saveImmediately = false)
        {
            PlayerPrefs.SetInt(SaveId, (int)data);
            if (saveImmediately)
                PlayerPrefs.Save();
        }

        public override object LoadData()
        {
            return PlayerPrefs.GetInt(SaveId, -1);
        }
    }
}
