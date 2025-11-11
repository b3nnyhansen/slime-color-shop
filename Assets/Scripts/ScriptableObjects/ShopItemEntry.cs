using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ShopItemEntry", menuName = "Data/ShopItemEntry")]
    public class ShopItemEntry : PlayerDataEntry
    {
        public int Cost;
        public Sprite ItemSprite;
        
        public override void SaveData(object data = null)
        {
            PlayerPrefs.SetInt(SaveId, 1);
        }

        public override object LoadData()
        {
            return PlayerPrefs.GetInt(SaveId, 0);
        }

        public bool IsBought()
        {
            return (int)LoadData() == 1;
        }

        public Sprite GetItemSprite()
        {
            return ItemSprite;
        }
    }
}
