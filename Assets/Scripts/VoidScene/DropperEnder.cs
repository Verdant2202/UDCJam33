using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperEnder : MonoBehaviour
{
    [SerializeField] DropperManager dropperManager;
    [SerializeField] SFXSO hitGround;
    [SerializeField] SFXSO falling;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SFXManager.Instance.PlaySFX(hitGround);
            SFXManager.Instance.StopSFX(falling);
            dropperManager.EndDropperSegment();
        }
    }
}
