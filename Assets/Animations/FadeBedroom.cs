using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeBedroom : MonoBehaviour
{
    public Image imageComponent; // Assign in Inspector
    public Animator animator;
    public Transform monster;
    public Image blackImage; // Assign in Inspector
    [SerializeField] Animator monsterAnimator;
    [SerializeField] string monsterAnimationName;

    [SerializeField] SongSO bedroomSong;

    [SerializeField] SFXSO wakeup;
    [SerializeField] SFXSO endgame;

    void Start()
    {
        MusicManager.Instance.PlaySong(bedroomSong);
        StartCoroutine(DisableAfterDelay());
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        imageComponent.enabled = false; // Disable the Image component
        animator.enabled = true;
        StartCoroutine(DisableAfterDelaye());
    }

    IEnumerator DisableAfterDelaye()
    {
        yield return new WaitForSeconds(0.15f); // Wait for 0.15 seconds
        SFXManager.Instance.PlaySFX(wakeup);
    }

    public void StartMonsterAnim()
    {
        monsterAnimator.Play(monsterAnimationName);
    }

    public void EndAnimSequence()
    {
        StartCoroutine(EndAnim());
    }

    IEnumerator EndAnim()
    {
        blackImage.enabled = true;
        MusicManager.Instance.StopSong(bedroomSong, 0f);
        SFXManager.Instance.PlaySFX(endgame);
        yield return new WaitForSeconds(6f);
        Loader.Load(Loader.Scene.MainMenu);
    }
}