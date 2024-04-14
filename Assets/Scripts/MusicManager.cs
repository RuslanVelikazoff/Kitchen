using System;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    private float volume = .3f;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, .3f);
        
        audioSource = GetComponent<AudioSource>();
    }

    public void ChangeVolume()
    {
        volume += .1f;
        
        if (volume > 1)
        {
            volume = 0f;
        }

        audioSource.volume = volume;
        
        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return volume;
    }
}
