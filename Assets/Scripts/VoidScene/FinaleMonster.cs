using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleMonster : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform.position);
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
    }
}
