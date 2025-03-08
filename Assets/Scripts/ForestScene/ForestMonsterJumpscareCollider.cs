using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestMonsterJumpscareCollider : MonoBehaviour
{
    [SerializeField] ForestMonster monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(monster.Jumpscare());
        }
 
    }
}
