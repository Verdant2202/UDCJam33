using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Transform swordPart;
    [SerializeField] Interactive chestInteractive;
    // Start is called before the first frame update
    void Start()
    {
        chestInteractive.EnableInteractive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SwordPartAnim()
    {
        yield return new WaitForSeconds(2f);
        swordPart.DOMoveY(swordPart.position.y + 1f, 2f);
        swordPart.DOScale(5f, 2f);
        yield return new WaitForSeconds(1.5f);
        swordPart.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
    }

    public void Open()
    {
        chestInteractive.EnableInteractive(false);
        anim.Play("Open");
        StartCoroutine(SwordPartAnim());
    }
}
