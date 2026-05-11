using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ShopItemEntry", menuName = "Data/ShopItemEntry")]
    public class ShopItemEntry : PlayerDataEntry
    {
        public int Cost;
        public Sprite ItemSprite;
        public string PlacementId => string.Format("{0}_PLACEMENT", SaveId);
        
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

        public void SetPlacementData(int value)
        {
            PlayerPrefs.SetInt(PlacementId, value);
        }

        public void SetPlacementData()
        {
            SetPlacementData(1);
        }

        public void UnsetPlacementData()
        {
            SetPlacementData(0);
        }

        public int LoadPlacementData()
        {
            return PlayerPrefs.GetInt(PlacementId, 0);
        }

        public bool IsPlaced()
        {
            return LoadPlacementData() == 1;
        }
    }
}
