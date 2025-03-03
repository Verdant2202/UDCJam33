using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Player player;
    [SerializeField] ScreenFade screenFade;
    private void Awake()
    {
        Instance = this;
    }

    public void PlayerJumpscare(Transform jumpscareCameraHolder, float moveCameraTime, float jumpscareDuration)
    {
        player.MoveAndDockCamera(jumpscareCameraHolder, moveCameraTime);
        StartCoroutine(screenFade.FadeIn(1f, jumpscareDuration));
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
