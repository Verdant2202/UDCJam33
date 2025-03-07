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
        
    }

    public void OpenDoor()
    {
        if(!InGameData.swordParts.Contains(requiredSwordPart))
        {
            //return;
        }
        anim.Play("OpenDoor");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
