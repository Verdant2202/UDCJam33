using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMonster : MonoBehaviour
{
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Animator anim;
    [SerializeField] Transform jumpscareCameraHolder;
    [SerializeField] float cameraJumpscareLerpTime = 0.05f;
    [SerializeField] float jumpscareDuration = 2f;
    [SerializeField] ForestJumpscareManager jumpscareManager;
    [SerializeField] MonsterForestNavmeshscript nav;
    public IEnumerator Jumpscare()
    {
        transform.LookAt(playerTransform);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        jumpscareManager.PlayerJumpscare(jumpscareCameraHolder, cameraJumpscareLerpTime, jumpscareDuration); //parameter is jumpscare camera holder transform, cameraJumpscareLerpTime is how long for camera to move to animation part
        nav.follow = false;
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
