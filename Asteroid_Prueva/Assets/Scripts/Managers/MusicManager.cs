using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource audioSource;
    public AudioClip[] playlist;

    private int currentSong = 0;
    private bool isFading = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //  No destruimos duplicados como pediste
    }

    void Start()
    {
        // Evitar que múltiples managers reproduzcan música a la vez
        if (instance != this)
        {
            audioSource.Stop();
            return;
        }

        PlaySong(currentSong);
    }

    void Update()
    {
        if (instance != this) return;

        //  Playlist automática
        if (!audioSource.isPlaying && !isFading)
        {
            NextSong();
        }
    }

    public void SetSong(int index)
    {
        if (instance != this) return;
        if (index < 0 || index >= playlist.Length) return;

        currentSong = index;
        PlaySong(currentSong);
    }

    void NextSong()
    {
        currentSong++;

        if (currentSong >= playlist.Length)
        {
            currentSong = 0;
        }

        PlaySong(currentSong);
    }

    void PlaySong(int index)
    {
        if (playlist.Length == 0) return;

        audioSource.clip = playlist[index];
        audioSource.volume = 1f;
        audioSource.Play();
    }

    //  Fade out + acción (cambio de escena)
    public IEnumerator FadeOutAndThen(Action onComplete, float duration = 3f)
    {
        if (instance != this) yield break;

        isFading = true;

        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / duration);
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;

        isFading = false;

        onComplete?.Invoke();
    }
}
