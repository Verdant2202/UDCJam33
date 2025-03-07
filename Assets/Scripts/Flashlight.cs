using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] ItemSO flashlightSO;
    [SerializeField] GameObject FlashLight;

    public void PickUp()
    {
        GameManager.Instance.AddItem(flashlightSO);
        FlashLight.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (InGameData.items.Contains(flashlightSO))
        {
            FlashLight.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
        else
        {
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
        }
    }

