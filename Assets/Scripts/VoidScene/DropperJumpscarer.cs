using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class DropperJumpscarer : MonoBehaviour
{
    [SerializeField] GameObject jumpScareImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void Jumpscare()
    {
        jumpScareImage.SetActive(true);
        await Task.Delay(100);
        jumpScareImage.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Jumpscare();
        }
    }
}
