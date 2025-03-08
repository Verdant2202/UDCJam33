using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] MonsterMaze monsterMaze;
    [SerializeField] SwordPartSO requiredSwordPartSO;
    [SerializeField] GameObject mazeGameObject;

    [SerializeField] SongSO mazeSong;
    [SerializeField] SongSO ambienceSong;
    public void StartMazeSegment()
    {
        monsterMaze.EnableMonster();
        MusicManager.Instance.PlaySong(mazeSong);
        MusicManager.Instance.StopSong(ambienceSong);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(InGameData.swordParts.Contains(requiredSwordPartSO))
        {
            mazeGameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
