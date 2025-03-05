using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadebedroom : MonoBehaviour
{
    public Image imageComponent; // Assign in Inspector
    public Animator animator;
    public AudioSource audioSource;
    public AudioSource show;
    public Transform monster;
    public Image blackImage; // Assign in Inspector

    void Start()
    {
        StartCoroutine(DisableAfterDelay());
    }

    IEnumerator DisableAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 seconds
        imageComponent.enabled = false; // Disable the Image component
        animator.enabled = true;
        
        StartCoroutine(DisableAfterDelaye());
    }
    IEnumerator DisableAfterDelaye()
    {
        yield return new WaitForSeconds(0.15f); // Wait for 0.15 seconds
        audioSource.enabled = true;
        StartCoroutine(DisableAfterDelayee());

    }
    IEnumerator DisableAfterDelayee()
    {
        yield return new WaitForSeconds(4f); // Wait for 4 seconds
        monster.position = new Vector3(0f, 403.161f, 0.495f);
        show.Play();
        StartCoroutine(DisableAfterDelayeee());
    }
    IEnumerator DisableAfterDelayeee()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        blackImage.enabled = true;
    }
}