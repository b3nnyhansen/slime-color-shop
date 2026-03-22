using UnityEngine;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "AudioEntry", menuName = "Data/AudioEntry")]
    public class AudioEntry : ScriptableObject
    {
        public AudioEnum audioEnum;
        public AudioClip audioClip;
    }
}