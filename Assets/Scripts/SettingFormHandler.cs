using SlimeColorShop.Audio;
using UnityEngine;

namespace SlimeColorShop
{
    public class SettingFormHandler : BaseFormHandler
    {
        [SerializeField] private GameButtonV2 bgmButton;
        [SerializeField] private SpecialGameButton bgmButtonSlider;
        [SerializeField] private GameButtonV2 sfxButton;
        [SerializeField] private SpecialGameButton sfxButtonSlider;
        
        public override void Init()
        {
            base.Init();
            InitButtons();
        }

        private void InitButtons()
        {
            bgmButton.Init(
                !InventoryManager.Instance.IsBGMMuted(),
                delegate
                {
                    ChangeBGMSetting();
                    bgmButtonSlider.SetIsOn(!InventoryManager.Instance.IsBGMMuted());
                }
            );
            bgmButtonSlider.Init(
                !InventoryManager.Instance.IsBGMMuted(),
                delegate
                {
                    ChangeBGMSetting();
                    bgmButton.SetIsOn(!InventoryManager.Instance.IsBGMMuted());
                }
            );
            sfxButton.Init(
                !InventoryManager.Instance.IsSFXMuted(),
                delegate
                {
                    ChangeSFXSetting();
                    sfxButtonSlider.SetIsOn(!InventoryManager.Instance.IsSFXMuted());
                }
            );
            sfxButtonSlider.Init(
                !InventoryManager.Instance.IsSFXMuted(),
                delegate
                {
                    ChangeSFXSetting();
                    sfxButton.SetIsOn(!InventoryManager.Instance.IsSFXMuted());
                }
            );
        }

        public void ChangeBGMSetting()
        {
            InventoryManager.Instance.ChangeBGMSetting();
            UniversalAudioManager.Instance.UpdateAudioVolume();
        }

        public void ChangeSFXSetting()
        {
            InventoryManager.Instance.ChangeSFXSetting();
            UniversalAudioManager.Instance.UpdateAudioVolume();
        }
    }
}