using UnityEngine;

namespace SlimeColorShop.Audio
{
    public class BGMAudioManager : BaseAudioManager
    {
        public override bool IsMuted()
        {
            return InventoryManager.Instance.IsBGMMuted();
        }
    }
}
