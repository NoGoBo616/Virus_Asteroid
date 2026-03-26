using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    private static GlobalAudioManager instance;
    public static GlobalAudioManager Instance
    {
        get
        {
            if (instance == null) Debug.Log("AudioManager is missing!");
            return instance;
        }
    }

    [Header("Audio Manager Configuration")]
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] musicList;
    public AudioClip[] sfxList;

    public AudioSource MusicSource => musicSource;

    private void Awake()
    {
        instance = this;
    }

    public void PlayMusic(int musicToPlay)
    {
        musicSource.clip = musicList[musicToPlay];
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayRandomMusic()
    {
        int randomMusicClip = Random.Range(0, musicList.Length);
        musicSource.clip = musicList[randomMusicClip];
        musicSource.Play();
    }

    public void PlaySFX(int sfxToPlay)
    {
        sfxSource.PlayOneShot(sfxList[sfxToPlay]);
    }
}
