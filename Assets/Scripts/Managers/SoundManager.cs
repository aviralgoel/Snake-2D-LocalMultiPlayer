using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get { return _instance; } }

    public bool IsMute { get => isMute; set => isMute = value; }

    public AudioSource backgroundMusicSource;
    public AudioSource SFXSource;
    private bool isMute;
    public SoundInfo[] ListOfSounds;

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
        isMute = false;

    }
    public void Play(SoundsNames sound)
    {
        if (isMute)
            return;
        AudioClip clip = getSoundClip(sound);
        
        if (clip != null && sound != SoundsNames.BackgroundMusic)
        {
            SFXSource.PlayOneShot(clip);
            Debug.Log(clip.name);

        }
        if (clip != null && sound == SoundsNames.BackgroundMusic)
        {
            backgroundMusicSource.Play();
        }
    }
    private AudioClip getSoundClip(SoundsNames sound)
    {
        return Array.Find(ListOfSounds, item => item.name == sound).clipName;
    }
}
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
