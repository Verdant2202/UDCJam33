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
    [SerializeField] Transform swordPartsUIHolder;
    private void Awake()
    {
        Instance = this;
    }

    public void CreateUI()
    {
        foreach(SwordPartSO SO in InGameData.swordParts)
        {
            Instantiate(SO.UIObject, swordPartsUIHolder);
        }
        foreach (ItemSO SO in InGameData.items)
        {

        }
    }

    public void AddSwordPart(SwordPartSO swordPartSO)
    {
        Instantiate(swordPartSO.UIObject, swordPartsUIHolder);
        InGameData.AddSwordPart(swordPartSO);
    }
    public void AddItem(ItemSO itemSO)
    {
        InGameData.AddItem(itemSO);
    }
    public void PlayerJumpscare(Transform jumpscareCameraHolder, float moveCameraTime, float jumpscareDuration)
    {
        player.MoveAndDockCamera(jumpscareCameraHolder, moveCameraTime);
        SceneReload(jumpscareDuration);
    }

    public async void SceneReload(float waitDuration)
    {
        StartCoroutine(screenFade.FadeIn(1f, waitDuration));
        await Task.Delay((int)(waitDuration * 1000) + 1000);
        Loader.Load(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
