using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ForestPlayer : MonoBehaviour
{
    [SerializeField] FirstPersonController movementController;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    
    public IEnumerator Freeze(float time)
    {
        movementController.cameraCanMove = false;
        movementController.playerCanMove = false;
        movementController.enabled = false;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(time);
        movementController.enabled = true;
        movementController.cameraCanMove = true;
        movementController.playerCanMove = true;
    }

    public void ChangeSpeed(float speed)
    {
        movementController.walkSpeed = speed;
    }
    public void ChangeBobSpeed(float speed)
    {
        movementController.bobSpeed = speed;
    }

    public async void DoForestAnimation()
    {
        movementController.cameraCanMove = false;
        movementController.playerCanMove = false;
        movementController.enabled = false; ;
        anim.enabled = true;
        rb.isKinematic = true;
        anim.Play("ForestAnimation");
        StartCoroutine(Freeze(3f));
        await Task.Delay(3000);
        HelpTextManager.Instance.ShowText("Run!", 2f);
        rb.isKinematic = false;
        anim.enabled = false;
        movementController.enabled = true;
        movementController.cameraCanMove = true;
        movementController.playerCanMove = true;
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



    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
