using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestSecondCollider : MonoBehaviour
{
    bool done = false;
    [SerializeField] ForestPlayer player;
    [SerializeField] GameObject monster;
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
        if (other.CompareTag("Player") && done == false)
        {
            monster.SetActive(true);
            player.DoForestAnimation();
            player.ChangeSpeed(6f);
            player.ChangeBobSpeed(15f);
            done = true;
        }
    }
}
