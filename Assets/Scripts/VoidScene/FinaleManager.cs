using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleManager : MonoBehaviour
{
    [SerializeField] ItemSO requiredItemSO;
    [SerializeField] GameObject toEnableGameObject;
    [SerializeField] Camera finaleCamera;
    [SerializeField] ScreenFade screenFade;
    [SerializeField] Animator monsterAnim;
    [SerializeField] Animator cameraAnim;
    [SerializeField] Player player;
    [SerializeField] Light playerFlashlight;
    [SerializeField] GameObject finaleLight;
    [SerializeField] GameObject katana;

    [SerializeField] SongSO ambienceSong;
    [SerializeField] SongSO monsterKillSong;

    [SerializeField] SFXSO monsterDeath;
    [SerializeField] PlayerFootstepsManager pFM;
    public void EnableFinale()
    {  
        if (InGameData.items.Contains(requiredItemSO))
        {
            toEnableGameObject.SetActive(true);
            monsterAnim.SetBool("idling", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    public IEnumerator DoCameraSwitch()
    {
        StartCoroutine(screenFade.FadeIn(1f, 0f));
        yield return new WaitForSeconds(2f);

        finaleCamera.depth = 100f;
        playerFlashlight.enabled = false;
        finaleLight.SetActive(true);
        katana.SetActive(false);

        StartCoroutine(screenFade.FadeOut(1f, 0.5f));
        yield return new WaitForSeconds(0.5f);
        MusicManager.Instance.StopSong(ambienceSong);
        MusicManager.Instance.PlaySong(monsterKillSong, 0.5f);
        cameraAnim.Play("CameraAnimation");

        yield return new WaitForSeconds(15f);

        StartCoroutine(screenFade.FadeIn(1f, 0f)); 
        MusicManager.Instance.StopSong(monsterKillSong);
        yield return new WaitForSeconds(1f);
        Loader.Load(Loader.Scene.BedroomScene);
        yield return null;
    }

    public void CallMonsterDeath()
    {
        SFXManager.Instance.PlaySFX(monsterDeath);
        monsterAnim.Play("Death");
    }
    public IEnumerator FinalAnimation()
    {
        pFM.soundsDisabled = true;
        player.PlayFinalAnim();
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
