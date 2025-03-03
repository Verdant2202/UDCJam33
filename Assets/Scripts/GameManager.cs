using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Player player;
    [SerializeField] ScreenFade screenFade;
    [SerializeField] Loader.Scene scene;
    private void Awake()
    {
        Instance = this;
    }

    public async void PlayerJumpscare(Transform jumpscareCameraHolder, float moveCameraTime, float jumpscareDuration)
    {
        player.MoveAndDockCamera(jumpscareCameraHolder, moveCameraTime);
        StartCoroutine(screenFade.FadeIn(1f, jumpscareDuration));
        await Task.Delay((int)(jumpscareDuration * 1000) + 1000);
        Loader.Load(scene);
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
