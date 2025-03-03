using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image blackScreen;

    void Start()
    {
        blackScreen.color = Color.black;
        StartCoroutine(FadeOut(1f, 1f));
    }

    public IEnumerator FadeOut(float fadeDuration, float waitBeforeStart)
    {
        yield return new WaitForSeconds(waitBeforeStart);

        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, elapsedTime / fadeDuration));
            yield return null;
        }

        blackScreen.gameObject.SetActive(false); // Hide it after fade
    }

    public IEnumerator FadeIn(float fadeDuration, float waitBeforeStart)
    {
        yield return new WaitForSeconds(waitBeforeStart);

        blackScreen.gameObject.SetActive(true); // Ensure the screen is visible
        float elapsedTime = 0f;
        blackScreen.color = new Color(0, 0, 0, 0); // Start fully transparent

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, elapsedTime / fadeDuration));
            yield return null;
        }
    }
}