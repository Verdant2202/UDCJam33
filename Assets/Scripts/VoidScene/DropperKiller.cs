using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperKiller : MonoBehaviour
{
    [SerializeField] SFXSO hitGroundSFX;
    [SerializeField] SFXSO fallingSFX;
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
        if (collision.transform.CompareTag("Player"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 normal = contact.normal;
            Debug.Log("Collision Normal: " + normal);

            if (Vector3.Dot(normal, Vector3.down) > 0.25f)
            {
                SFXManager.Instance.PlaySFX(hitGroundSFX);
                SFXManager.Instance.StopSFX(fallingSFX);
                GameManager.Instance.SceneReload(0f, 0.1f);
            }
        }
    }
}
