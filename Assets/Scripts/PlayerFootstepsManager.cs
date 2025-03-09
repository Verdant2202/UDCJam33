using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepsManager : MonoBehaviour
{
    [SerializeField] FirstPersonController movement;

    [SerializeField] SFXSO walkSound;
    [SerializeField] SFXSO sprintSound;
    [SerializeField] AudioSource walkAudioSource;
    [SerializeField] AudioSource sprintAudioSource;
    [SerializeField] ForestPlayer fP;

    public bool soundsDisabled;
    // Start is called before the first frame update
    void Start()
    {
        soundsDisabled = false;
        walkAudioSource.clip = walkSound.clip;
        sprintAudioSource.clip = sprintSound.clip;
    }

    // Update is called once per frame
    void Update()
    {
        walkAudioSource.volume = walkSound.naturalVolume * SFXManager.Instance.globalSFXVolume;
        sprintAudioSource.volume = sprintSound.naturalVolume * SFXManager.Instance.globalSFXVolume;
        if (movement.isSprinting)
        {
            sprintAudioSource.enabled = true;
            walkAudioSource.enabled = false;
        }
        else if(movement.isWalking)
        {
            sprintAudioSource.enabled = false;
            walkAudioSource.enabled = true;
        }
        else
        {
            walkAudioSource.enabled = false;
            sprintAudioSource.enabled = false;
        }

        if (Time.timeScale == 0f || !movement.isGrounded || soundsDisabled)
        {
            walkAudioSource.enabled = false;
            sprintAudioSource.enabled = false;
        }
        if (fP != null)
        {
            if(fP.frozen)
            {
                walkAudioSource.enabled = false;
                sprintAudioSource.enabled = false;
            }
        }
    }
}
