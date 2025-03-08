using UnityEngine;

[CreateAssetMenu(fileName = "New SFX", menuName = "Audio/SFX", order = 1)]
public class SFXSO : ScriptableObject
{
    public string sfxName; // A name for the sound effect, optional.
    public AudioClip clip; // The AudioClip for the sound effect.
    [Range(0f, 1f)] public float naturalVolume = 1f; // The natural volume of the sound effect.
    public bool isLooped; // Whether or not the SFX should loop when played.

    // You can add more properties as needed, like pitch, pan, etc.
}