using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "DecorationEntry", menuName = "Data/DecorationEntry")]
    public class DecorationEntry : ScriptableObject
    {
        public string DecorationName;
        public Sprite DecorationSprite;
    }
}
