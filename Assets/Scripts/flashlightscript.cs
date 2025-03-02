using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightscript : MonoBehaviour
{
    [SerializeField] GameObject FlashLigh;
    [SerializeField] bool FlashLighequiped;
    // Start is called before the first frame update
    void Start()
    {
        FlashLigh.gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
       
        }
    }

