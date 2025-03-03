using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterJumpscareCollider : MonoBehaviour
{
    [SerializeField] MonsterMaze monsterMaze;
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
            done = true;
            monsterMaze.MazeJumpscare();
        }
    }
}
