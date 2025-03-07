using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] FirstPersonController movementController;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Animator anim;

    [SerializeField] Rigidbody rb;
    private Interactive currentSelectedInteractive;


    [SerializeField] FinaleManager finaleManager;
    public void CallMonsterDeath()
    {
        finaleManager.CallMonsterDeath();
    }

    public void DoCameraSwitch()
    {
        StartCoroutine(finaleManager.DoCameraSwitch());
    }
    public void PlayFinalAnim()
    {
        anim.enabled = true;
        rb.isKinematic = true;
        rb.useGravity = false;
        movementController.enabled = false;
        anim.Play("FinalAnimation");
    }
    public void GetJumpscared(Transform jumpscareCameraHolder, float lerpTime)
    {
        movementController.playerCanMove = false;
        MoveAndDockCamera(jumpscareCameraHolder, lerpTime);
    }
    public void MoveAndDockCamera(Transform parent, float time)
    {
        movementController.cameraCanMove = false;
        cameraTransform.parent = parent;
        StartCoroutine(LerpCamera(parent, time));
    }

    IEnumerator LerpCamera(Transform jumpscareCameraHolder, float time)
    {
        float elapsedTime = 0f;
        Vector3 startPos = cameraTransform.position;
        Quaternion startRot = cameraTransform.rotation;

        Vector3 targetPos = jumpscareCameraHolder.position;
        Quaternion targetRot = jumpscareCameraHolder.rotation;

        while (elapsedTime < time)
        {
            //Debug.Log(cameraTransform.position + " " + jumpscareCameraHolder.position);
            float t = elapsedTime / time;
            cameraTransform.position = Vector3.Lerp(startPos, targetPos, t);
            cameraTransform.rotation = Quaternion.Lerp(startRot, targetRot, t);
            //cameraTransform.position = targetPos;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    void HandleInteractives()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(cameraTransform.position, cameraTransform.forward);
        currentSelectedInteractive = null;
        foreach(RaycastHit hit in raycastHits)
        {
            if (hit.transform.TryGetComponent(out Interactive hitInteractive))
            {
                if (hitInteractive.interactiveEnabled)
                {
                    currentSelectedInteractive = hitInteractive;
                    break;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && currentSelectedInteractive != null)
        {
            currentSelectedInteractive.Interact();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInteractives();
    }
}
