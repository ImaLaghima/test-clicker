using System.Collections.Generic;
using UnityEngine;

namespace TestClicker
{
    [DisallowMultipleComponent]
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }
        
        [SerializeField]
        private AudioSource musicAudioSource;
        
        [SerializeField]
        private bool interruptIfAllBusy = true;
        
        [SerializeField]
        private List<AudioSource> coinAudioSources;
        
        [SerializeField]
        private List<AudioSource> upgradeAudioSources;

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        private void Start()
        {
            musicAudioSource.Play();
        }

        public void PlayCoinSFX()
        {
            DelegateToFreeAudioSource(coinAudioSources);
        }

        public void PlayUpgradeSFX()
        {
            DelegateToFreeAudioSource(upgradeAudioSources);
        }

        private void DelegateToFreeAudioSource(List<AudioSource> audioSources)
        {
            foreach (AudioSource source in audioSources)
            {
                if (!source.isPlaying)
                {
                    source.Play();
                    return;
                }
            }
            
            if (interruptIfAllBusy)
            {
                audioSources[0].Stop();
                audioSources[0].Play();
            }
        }
    }
}
