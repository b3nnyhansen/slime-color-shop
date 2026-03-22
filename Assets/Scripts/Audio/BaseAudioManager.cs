using UnityEngine;

namespace SlimeColorShop.Audio
{
    public abstract class BaseAudioManager : MonoBehaviour
    {
        protected AudioSource audioSource;
        protected AudioEnum currentAudioEnum;

        public virtual void Init()
        {
            audioSource = GetComponent<AudioSource>();
            currentAudioEnum = AudioEnum.NONE;
        }

        public virtual void PlayAudio(AudioEnum audioEnum)
        {
            if (currentAudioEnum == audioEnum && audioSource.loop)
                return;
            
            currentAudioEnum = audioEnum;
            AudioClip audioClip = InventoryManager.Instance.GetAudioClip(audioEnum);
            if (audioClip == null)
                return;
            
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void UpdateAudioVolume()
        {
            if(IsMuted())
                audioSource.volume = 0f;
            else
                audioSource.volume = 1f;
        }

        public abstract bool IsMuted();
    }
}
