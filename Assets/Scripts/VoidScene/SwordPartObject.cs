using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SwordPartObject : MonoBehaviour
{
    [SerializeField] SwordPartSO swordPartSO;
    [SerializeField] Transform swordPartTransform;
    [SerializeField] Interactive interactive;
    [SerializeField] SFXSO pickUpSFX;
    public void PickUp()
    {
        SFXManager.Instance.PlaySFX(pickUpSFX);
        interactive.EnableInteractive(false);
        swordPartTransform.DOScale(new Vector3(0, 0, 0), 0.5f);
        GameManager.Instance.AddSwordPart(swordPartSO);
        GameManager.Instance.SceneReload(1.5f, 1f);
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
