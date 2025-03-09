using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlaceWallEnd : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] SongSO maze;
    [SerializeField] SongSO ambience;
    bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        done = false;
        wall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && done == false)
        {
            MusicManager.Instance.StopSong(maze);
            MusicManager.Instance.PlaySong(ambience);
            HelpTextManager.Instance.ShowText("Open The lost samurai chest", 1f);
            wall.SetActive(true);
            done = true;
        }
    }
}
