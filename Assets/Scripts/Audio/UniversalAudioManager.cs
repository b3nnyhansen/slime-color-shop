using UnityEngine;

namespace SlimeColorShop.Audio
{
    public class UniversalAudioManager : Singleton<UniversalAudioManager>
    {
        [SerializeField] protected BaseAudioManager bgmAudioManager;
        [SerializeField] protected BaseAudioManager sfxAudioManager;

        protected override void Awake()
        {
            base.Awake();
            bgmAudioManager.Init();
            sfxAudioManager.Init();
        }

        public void PlayBGM(AudioEnum audioEnum)
        {
            bgmAudioManager.PlayAudio(audioEnum);
        }

        public void PlaySFX(AudioEnum audioEnum)
        {
            sfxAudioManager.PlayAudio(audioEnum);
        }

        public void UpdateAudioVolume()
        {
            bgmAudioManager.UpdateAudioVolume();
            sfxAudioManager.UpdateAudioVolume();
        }
    }
}
