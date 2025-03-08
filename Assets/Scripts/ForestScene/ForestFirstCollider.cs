using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestFirstCollider : MonoBehaviour
{
    [SerializeField] Animator monsterAnimator;
    [SerializeField] ForestPlayer player;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

     
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && done == false)
        {
            monsterAnimator.Play("FirstAnimation");
            StartCoroutine(player.Freeze(3f));
            player.ChangeSpeed(4f);
            player.ChangeBobSpeed(12f);
            done = true;
        }
    }
}
