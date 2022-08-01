using System;
using UnityEngine;

// Purpose: Singleton pattern based script for the Sound Management in game.
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance
    { get { return _instance; } }

    public bool IsMute { get => isMute; set => isMute = value; }

    public AudioSource backgroundMusicSource;
    public AudioSource SFXSource;
    private bool isMute;
    public SoundInfo[] ListOfSounds; // class that holds Audioclip clip and Enum name (defined at the bottom)

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // play background music as soon as the game is loaded
        backgroundMusicSource.Play();
        isMute = false; // by default the game is not muted
    }

    public void Play(SoundsNames sound)
    {
        if (isMute)
            return;

        AudioClip clip = getSoundClip(sound);

        if (clip != null && sound != SoundsNames.BackgroundMusic)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    public void Stop(SoundsNames sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null && sound == SoundsNames.BackgroundMusic)
        {
            backgroundMusicSource.Stop();
        }
    }

    // given the audio by name, find the clip associated with it in the list of SoundInfo objects
    private AudioClip getSoundClip(SoundsNames sound)
    {
        return Array.Find(ListOfSounds, item => item.name == sound).clipName;
    }

    public void SetIsMute(bool _status)
    {
        isMute = _status; // new state of isMute
        SFXSource.mute = _status;
        backgroundMusicSource.mute = _status;
    }
}

// enum of different SoundNames
public enum SoundsNames
{
    ButtonClick,
    BackgroundMusic,
    PositiveCollectiblePickup,
    NegativeCollectiblePickup
}

[System.Serializable]
public class SoundInfo
{
    public SoundsNames name;
    public AudioClip clipName;
};