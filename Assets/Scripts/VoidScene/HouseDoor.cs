using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseDoor : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] SwordPartSO requiredSwordPart;
    // Start is called before the first frame update
    void Start()
    {
        if(InGameData.doorOpen)
        {
            anim.Play("OpenDoor");
        }
    }

    public void OpenDoor()
    {
        if(!InGameData.swordParts.Contains(requiredSwordPart))
        {
            //return;
        }
        InGameData.doorOpen = true;
        anim.Play("OpenDoor");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
