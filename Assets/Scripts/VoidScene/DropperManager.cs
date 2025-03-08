using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperManager : MonoBehaviour
{
    [SerializeField] SwordPartSO requiredSwordPartSO;
    [SerializeField] GameObject toDisableGameObject;
    [SerializeField] Light playerFlashlight;
    [SerializeField] FirstPersonController playerFPSController;
    [SerializeField] Rigidbody playerRigidbody;
    [SerializeField] float playerDropperLightIntensity;
    [SerializeField] float playerDropperLightRange;
    [SerializeField] float lightChangeLerpDuration;
    [SerializeField] float playerDropperMoveSpeed = 12f;

    [SerializeField] SongSO dropperSong;
    [SerializeField] SongSO ambienceSong;

    [SerializeField] SFXSO fallingSFX;
    bool segmentOn = false;
    float defaultRange;
    float defaultIntensity;
    // Start is called before the first frame update
    void Start()
    {
        segmentOn = false;
        defaultRange = playerFlashlight.range;
        defaultIntensity = playerFlashlight.intensity;
        if (InGameData.swordParts.Contains(requiredSwordPartSO))
        {
            toDisableGameObject.SetActive(false);
        }
    }

    public void StartDropperSegment()
    {
        segmentOn = true;
        playerFPSController.walkSpeed = playerDropperMoveSpeed;
        playerFPSController.sprintSpeed = playerDropperMoveSpeed;
        StartCoroutine(LerpLightIntensity(playerFlashlight, playerDropperLightIntensity, playerDropperLightRange, lightChangeLerpDuration));
        MusicManager.Instance.PlaySong(dropperSong);
        MusicManager.Instance.StopSong(ambienceSong);
        SFXManager.Instance.PlaySFX(fallingSFX);
    }
    public void EndDropperSegment()
    {
        segmentOn = false;
        playerFPSController.walkSpeed = 4f;
        playerFPSController.sprintSpeed = 7f;
        MusicManager.Instance.StopSong(dropperSong);
        MusicManager.Instance.PlaySong(ambienceSong);
        StartCoroutine(LerpLightIntensity(playerFlashlight, defaultIntensity, defaultRange, lightChangeLerpDuration));
    }
    private IEnumerator LerpLightIntensity(Light light, float targetIntensity, float targetRange, float duration)
    {
        float startIntensity = light.intensity;
        float startRange = light.range;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            light.intensity = Mathf.Lerp(startIntensity, targetIntensity, t);
            light.range = Mathf.Lerp(startRange, targetRange, t);
            yield return null;
        }

        light.intensity = targetIntensity;
        light.range = targetRange;
    }


    // Update is called once per frame
    void Update()
    {
        if(segmentOn)
        {
            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, Mathf.Clamp(playerRigidbody.velocity.y, -50f, 50f), playerRigidbody.velocity.z);
        }
    }
}
