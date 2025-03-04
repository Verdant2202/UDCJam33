using UnityEngine;
using System.Collections;

public class Animationcamera : MonoBehaviour
{
    public Animator animator;
    public float time = 1f;
    void Start()
    {
        StartCoroutine(CallFunctionAfterDelay());
    }

    IEnumerator CallFunctionAfterDelay()
    {
        yield return new WaitForSeconds(time); // Wait 0.3 seconds
        MyFunction(); // Call the function
    }

    void MyFunction()
    {
        animator.enabled = false;
    }
}