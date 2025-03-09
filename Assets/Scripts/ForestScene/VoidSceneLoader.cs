using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VoidSceneLoader : MonoBehaviour
{
    [SerializeField] ScreenFade screenFade;
    [SerializeField] SongSO song1;
    [SerializeField] SongSO song2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loadscene()
    {
        yield return new WaitForSeconds(2f);
        Loader.Load(Loader.Scene.VoidScene);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            MusicManager.Instance.StopSong(song1);
            MusicManager.Instance.StopSong(song2);
            StartCoroutine(screenFade.FadeIn(0.1f, 0f));
            StartCoroutine(Loadscene());
        }
    }
}
