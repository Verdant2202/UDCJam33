using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        HelpTextManager.Instance.ShowText("Enter the maze", 0.5f);
    }
}
