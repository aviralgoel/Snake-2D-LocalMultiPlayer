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
              

    }
    public void Start()
    {
        
       
        SoundManager.Instance.Play(SoundsNames.BackgroundMusic);
        isMute = false;
        Debug.Log("Starting..");
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
    private AudioClip getSoundClip(SoundsNames sound)
    {
        return Array.Find(ListOfSounds, item => item.name == sound).clipName;
    }
    public void SetIsMute(bool _status)
    {
        Debug.Log("Menu UI MUTE Button " + _status);
        isMute = _status;
        SFXSource.mute = _status;
        backgroundMusicSource.mute = _status;
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
