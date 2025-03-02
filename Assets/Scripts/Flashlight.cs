using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] GameObject FlashLight;
    [SerializeField] bool FlashLightEquipped;
    // Start is called before the first frame update
    void Start()
    {
        FlashLight.gameObject.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
       
        }
    }

