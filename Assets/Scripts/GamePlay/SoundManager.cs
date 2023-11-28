//**************************************************
// SoundManager.cs
//
// Code Soldiers 2019
//
// Author: Rafał Kania
// Creation Date: 29 December 2019
//**************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeSoldiers
{

    public enum AudioClipType
    {
        TileClick = 0,
        PositiveTiles,
        NegativeTiles,
        TilesFound
    }

	public class SoundManager : MonoBehaviour
	{
		//Singleton
		public static SoundManager Instance;

        [SerializeField]
        List<AudioSource> gameAudioSources = new List<AudioSource>();
        public List<AudioSource> _GameAudioSources
        {
            get
            {
                return gameAudioSources;
            }
        }


        [SerializeField]
        List<AudioClip> audioClips = new List<AudioClip>();
        public List<AudioClip> _AudioClips
        {
            get
            {
                return audioClips;
            }
        }
		
		void Awake()
		{
			if (Instance != null)
				Destroy(gameObject);
			else
				Instance = this;
		}
		
		void Start()
		{
			
		}
		
		void Update()
		{
			
		}

        public void EnabeSound()
        {
            foreach(AudioSource audio in gameAudioSources)
            {
                audio.mute = false;
            }
        }

        public void DisableSound()
        {
            foreach (AudioSource audio in gameAudioSources)
            {
                audio.mute = true;
            }
        }

        public void SetSound(bool value)
        {
            foreach (AudioSource audio in gameAudioSources)
            {
                audio.mute = value;
            }

            GameManager.Instance.soundDisabled = value;
            //GameManager.Instance._GameEvents.CallOnSoundEnabled(value);
        }

        public void PlaySoundFX(int index)
        {
            gameAudioSources[1].PlayOneShot(audioClips[index]);
        }

    }
}
