using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    [Range(0f, 1f)]
    public float globalSFXVolume = 1f;

    [System.Serializable]
    public class SFX
    {
        public SFXSO sfxData;
        [HideInInspector] public AudioSource source;
    }

    public List<SFX> sfxList = new List<SFX>();
    private Dictionary<SFXSO, AudioSource> activeSFX = new Dictionary<SFXSO, AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSFX();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeSFX()
    {
        foreach (var sfx in sfxList)
        {
            sfx.source = gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.sfxData.clip;
            sfx.source.loop = sfx.sfxData.isLooped;
            sfx.source.volume = 0f;
            sfx.source.playOnAwake = false;
        }
    }

    public void StopAllSFX()
    {
        foreach(SFX sfx in sfxList)
        {
            StopSFX(sfx.sfxData, 0f);
        }
    }
    public void PlaySFX(SFXSO sfxData, float fadeInTime = 0f)
    {
        SFX sfx = sfxList.Find(s => s.sfxData == sfxData);
        if (sfx != null && !sfx.source.isPlaying)
        {
            sfx.source.volume = 0f;
            sfx.source.Play();
            StartCoroutine(FadeAudio(sfx.source, 0f, sfx.sfxData.naturalVolume * globalSFXVolume, fadeInTime));
        }
        else
        {
            Debug.LogWarning("SFX not found: " + sfxData.sfxName);
        }
    }

    public void StopSFX(SFXSO sfxData, float fadeOutTime = 0f)
    {
        SFX sfx = sfxList.Find(s => s.sfxData == sfxData);
        if (sfx != null && sfx.source.isPlaying)
        {
            StartCoroutine(FadeAudio(sfx.source, sfx.source.volume, 0f, fadeOutTime, stopAfterFade: true));
        }
    }

    public void UpdateSFXVolume()
    {
        foreach (var sfx in sfxList)
        {
            if (sfx.source.isPlaying)
            {
                sfx.source.volume = sfx.sfxData.naturalVolume * globalSFXVolume;
            }
        }
    }

    public void ChangeSFXVolume(float volume)
    {
        globalSFXVolume = Mathf.Clamp01(volume); // Clamp the volume to be between 0 and 1
        UpdateSFXVolume();
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
        UpdateSFXVolume();
    }


}