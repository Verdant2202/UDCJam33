using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlaceWall : MonoBehaviour
{
    [SerializeField] GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            wall.SetActive(true);
        }
    }
}
