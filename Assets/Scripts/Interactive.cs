using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Interactive : MonoBehaviour
{
    public bool interactiveEnabled = true;
    public UnityEvent interactiveAction;
    public string Keyword;
    public void EnableInteractive(bool enable)
    {
        interactiveEnabled = enable;
    }
    public void SetInteractiveFunction(UnityEvent action)
    {
        interactiveAction = action;
    }

    public void Interact()
    {
        interactiveAction?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
