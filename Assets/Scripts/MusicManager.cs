using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [Range(0f, 1f)]
    public float globalMusicVolume = 1f;

    [System.Serializable]
    public class Song
    {
        public SongSO songData;
        [HideInInspector] public AudioSource source;
        [HideInInspector] public float currentTime;  // Store the playback position
    }

    public List<Song> songs = new List<Song>();
    private HashSet<Song> previouslyPlayingSongs = new HashSet<Song>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSongs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSongs()
    {
        foreach (var song in songs)
        {
            song.source = gameObject.AddComponent<AudioSource>();
            song.source.clip = song.songData.clip;
            song.source.loop = true;
            song.source.volume = 0f;
            song.source.playOnAwake = false;
        }
    }

    public void PlaySong(SongSO songData, float fadeInTime = 1f)
    {
        Song song = songs.Find(s => s.songData == songData);
        if (song != null && !song.source.isPlaying)
        {
            song.source.volume = 0f;
            song.source.Play();
            StartCoroutine(FadeAudio(song.source, 0f, song.songData.naturalVolume * globalMusicVolume, fadeInTime));
        }
        else
        {
            Debug.LogWarning("Song not found: " + songData.songName);
        }
    }

    public void StopSong(SongSO songData, float fadeOutTime = 1f)
    {
        Song song = songs.Find(s => s.songData == songData);
        if (song != null && song.source.isPlaying)
        {
            song.currentTime = song.source.time;  // Save the current position
            StartCoroutine(FadeAudio(song.source, song.source.volume, 0f, fadeOutTime, stopAfterFade: true));
        }
    }

    public void UpdateMusicVolume()
    {
        foreach (var song in songs)
        {
            if (song.source.isPlaying)
            {
                song.source.volume = song.songData.naturalVolume * globalMusicVolume;
            }
        }
    }

    public void StopAllSongs(float fadeOutTime = 0.5f)
    {
        previouslyPlayingSongs.Clear(); // Reset the tracking list

        foreach (var song in songs)
        {
            if (song.source.isPlaying)
            {
                song.currentTime = song.source.time; // Save the current position
                previouslyPlayingSongs.Add(song); // Track songs that were playing
                StartCoroutine(FadeAudio(song.source, song.source.volume, 0f, fadeOutTime, stopAfterFade: true));
            }
        }
    }

    public void ResumeAllSongs(float fadeInTime = 0.5f)
    {
        foreach (var song in previouslyPlayingSongs)
        {
            song.source.time = song.currentTime;  // Resume from saved position
            song.source.volume = 0f;
            song.source.Play();
            StartCoroutine(FadeAudio(song.source, 0f, song.songData.naturalVolume * globalMusicVolume, fadeInTime));
        }

        previouslyPlayingSongs.Clear(); // Clear the list after resuming
    }

    private IEnumerator FadeAudio(AudioSource audioSource, float startVol, float endVol, float duration, bool stopAfterFade = false)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            audioSource.volume = Mathf.Lerp(startVol, endVol, time / duration);
            yield return null;
        }
        audioSource.volume = endVol;

        if (stopAfterFade)
        {
            audioSource.Stop();
        }
    }

    private void Update()
    {
        UpdateMusicVolume();
    }
}