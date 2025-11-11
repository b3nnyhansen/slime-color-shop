using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "DecorationEntry", menuName = "Data/DecorationEntry")]
    public class DecorationEntry : PlayerDataEntry
    {
        public override void SaveData(object data)
        {
            PlayerPrefs.SetInt(SaveId, (int)data);
        }

        public override object LoadData()
        {
            return PlayerPrefs.GetInt(SaveId, -1);
        }
    }
}
