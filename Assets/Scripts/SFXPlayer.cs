using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] SFXSO forestJumpscare;
    [SerializeField] SFXSO Jumpscare;
    [SerializeField] SFXSO ChestOpen;

    public void PlayForestJumpscare()
    {
        SFXManager.Instance.PlaySFX(forestJumpscare);
    }

    public void PlayJumpscare()
    {
        SFXManager.Instance.PlaySFX(Jumpscare);
    }
    public void PlayChestOpen()
    {
        SFXManager.Instance.PlaySFX(ChestOpen);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
