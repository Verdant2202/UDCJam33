using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterForestNavmeshscript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    public bool follow = true;
    private void Start()
    {
        follow = true;
    }
    void Update()
    {
        if(follow == true)
        {
            agent.SetDestination(player.position);
        }

    }
}
