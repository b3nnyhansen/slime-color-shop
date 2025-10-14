using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "ShopItemEntry", menuName = "Data/ShopItemEntry")]
    public class ShopItemEntry : ScriptableObject
    {
        public int Cost;
    }
}
