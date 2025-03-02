using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicationLight : MonoBehaviour
{
    [SerializeField] Material mainMaterial;
    private Material lightMaterial;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Transform PlayerCamera;
   
    [SerializeField] float minAlphaDist = 50f;
    [SerializeField] float maxAlphaDist = 200f; 


    // Start is called before the first frame update
    void Start()
    {
        lightMaterial = new Material(mainMaterial);
        meshRenderer.material = lightMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerCamera.position);
        float dist = Vector3.Distance(PlayerCamera.position, transform.position);
        float alphaValue = Mathf.Clamp(Mathf.Clamp(dist, minAlphaDist, maxAlphaDist)/maxAlphaDist, 0.1f, 1f);
        Debug.Log(alphaValue);
        lightMaterial.SetColor("_Color", mainMaterial.GetColor("_Color") * alphaValue);

        if(dist < minAlphaDist)
        {
            meshRenderer.enabled = false;
        }
        else
        {
            meshRenderer.enabled = true;
        }
    }
}
