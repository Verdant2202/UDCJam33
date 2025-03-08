using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class ForestJumpscareManager : MonoBehaviour
{
    [SerializeField] ForestPlayer player;
    [SerializeField] ScreenFade screenFade;
    public void PlayerJumpscare(Transform jumpscareCameraHolder, float moveCameraTime, float jumpscareDuration)
    {
        player.MoveAndDockCamera(jumpscareCameraHolder, moveCameraTime);
        SceneReload(jumpscareDuration, 1f);
    }

    public async void SceneReload(float waitDuration, float fadeDuration)
    {
        StartCoroutine(screenFade.FadeIn(fadeDuration, waitDuration));
        await Task.Delay((int)(waitDuration * 1000) + (int)(fadeDuration * 1000));
        Loader.Load(Loader.Scene.ForestScene);
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
