using UnityEngine;
using System.Collections.Generic;

namespace SlimeColorShop.Data
{
    [CreateAssetMenu(fileName = "AudioDatabase", menuName = "Database/AudioDatabase")]
    public class AudioDatabase : ScriptableObject
    {
        public List<AudioEntry> audioEntries;

        public AudioClip GetAudioClip(AudioEnum audioEnum)
        {
            AudioEntry entry = audioEntries.Find(entry => entry.audioEnum == audioEnum);
            if (entry == null)
                return null;
            
            return entry.audioClip;
        }
    }
}