using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HelpTextManager : MonoBehaviour
{
    public static HelpTextManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField] TextMeshProUGUI helpText;

    //text - text to show
    //fadeAfter - how long the text should be at 100% opacity
    //waitTime - wait time before starting fade in
    //fadeInTime - how long the text should be fading in
    //fadeOutTime - how long should the text be fading out
    public void ShowText(string text, float fadeAfter = 3f, float waitTime = 0f, float fadeInTime = 0.8f,  float fadeOutTime = 0.8f)
    {
        StartCoroutine(FadeTextRoutine(text, waitTime, fadeInTime, fadeAfter, fadeOutTime));
    }

    private IEnumerator FadeTextRoutine(string text, float waitTime, float fadeInTime, float fadeAfter, float fadeOutTime)
    {
        yield return new WaitForSeconds(waitTime);
        helpText.enabled = true;
        helpText.text = text;
        Color color = helpText.color;
        color.a = 0;
        helpText.color = color;

        // Fade In
        for (float t = 0; t < fadeInTime; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(0, 1, t / fadeInTime);
            helpText.color = color;
            yield return null;
        }
        color.a = 1;
        helpText.color = color;

        // Wait at full opacity
        yield return new WaitForSeconds(fadeAfter);

        // Fade Out
        for (float t = 0; t < fadeOutTime; t += Time.deltaTime)
        {
            color.a = Mathf.Lerp(1, 0, t / fadeOutTime);
            helpText.color = color;
            yield return null;
        }
        color.a = 0;
        helpText.color = color;
        helpText.enabled = false;
    }
}
