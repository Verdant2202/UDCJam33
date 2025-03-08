using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeStartCollider : MonoBehaviour
{
    [SerializeField] MazeManager mazeManager;
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
        if (other.CompareTag("Player"))
        {
            HelpTextManager.Instance.ShowText("Find the lost chest of The Samurai", 2f);
            mazeManager.StartMazeSegment();
            Destroy(gameObject);
        }
    }
}
