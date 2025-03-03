using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Animator anim;
    [SerializeField] Transform jumpscareCameraHolder;
    [SerializeField] float cameraJumpscareLerpTime = 0.1f;
    [SerializeField] float jumpscareDuration = 2f;
    public IEnumerator Jumpscare()
    {
        transform.LookAt(playerTransform);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        GameManager.Instance.PlayerJumpscare(jumpscareCameraHolder, cameraJumpscareLerpTime, jumpscareDuration); //parameter is jumpscare camera holder transform, cameraJumpscareLerpTime is how long for camera to move to animation part

        yield return new WaitForSeconds(cameraJumpscareLerpTime);
        anim.Play("Jumpscare");

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
