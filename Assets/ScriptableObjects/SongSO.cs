using UnityEngine;

[CreateAssetMenu(fileName = "NewSong", menuName = "Music/SongSO")]
public class SongSO : ScriptableObject
{
    public string songName;
    public AudioClip clip;
    [Range(0f, 1f)] public float naturalVolume = 1f;
}