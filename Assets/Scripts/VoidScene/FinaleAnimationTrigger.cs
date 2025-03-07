using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleAnimationTrigger : MonoBehaviour
{
    [SerializeField] FinaleManager finaleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEndAnim()
    {
        StartCoroutine(finaleManager.FinalAnimation());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayEndAnim();
        }
    }
}
