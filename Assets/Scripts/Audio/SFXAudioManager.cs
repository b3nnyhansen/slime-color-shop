using UnityEngine;

namespace SlimeColorShop.Audio
{
    public class SFXAudioManager : BaseAudioManager
    {
        public override bool IsMuted()
        {
            return InventoryManager.Instance.IsSFXMuted();
        }
    }
}
