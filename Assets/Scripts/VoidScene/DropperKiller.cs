using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            GameManager.Instance.SceneReload(0f, 0.1f);
        }
    }
}
