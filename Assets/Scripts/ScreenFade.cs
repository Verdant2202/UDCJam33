using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    public Image blackScreen;
    public float fadeDuration = 1f;

    void Start()
    {
        blackScreen.color = Color.black;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        float elapsedTime = 0f;
        Color originalColor = blackScreen.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            blackScreen.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, elapsedTime / fadeDuration));
            yield return null;
        }

        blackScreen.gameObject.SetActive(false); // Hide it after fade
    }
}