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
    [SerializeField] Transform itemsUIHolder;
    [SerializeField] GameObject itemsUIField;
    [SerializeField] ItemSO katanaSO;
    [SerializeField] GameObject playerKatana;
    [SerializeField] FinaleManager finaleManager;
    [SerializeField] GameObject pauseMenuGameObject;

    [SerializeField] List<SwordPartSO> requiredSwordPartsForSword;
    private void Awake()
    {
        Instance = this;
    }

    public void Resume()
    {
        pauseMenuGameObject.SetActive(false);
        player.SetActiveMovementController(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuGameObject.SetActive(true); 
        player.SetActiveMovementController(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void PauseSceneReload()
    {
        Time.timeScale = 1f;
        SceneReload(0.1f, 0.6f);
    }

    public void PauseQuit()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenu);
    }


    public void CraftSword()
    {
        foreach (SwordPartSO so in requiredSwordPartsForSword)
        {
            if (!InGameData.swordParts.Contains(so))
            {
                HelpTextManager.Instance.ShowText("You need all katana parts in order to craft the katana", 2f, 0f, 0.9f, 0.9f);
                return;
            }
        }
        foreach (SwordPartSO so in requiredSwordPartsForSword)
        {
            InGameData.swordParts.Remove(so);
        }
        foreach (Transform child in swordPartsUIHolder)
        {
            Destroy(child.gameObject);
        }
        playerKatana.SetActive(true);
        InGameData.AddItem(katanaSO);
        CreateUI();
        finaleManager.EnableFinale();
        HelpTextManager.Instance.ShowText("GO KILL THE MONSTER", 3f, 0f, 0.5f, 0.5f);
    }

    public void CreateUI()
    {
        foreach (Transform child in swordPartsUIHolder)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in itemsUIHolder)
        {
            Destroy(child.gameObject);
        }
        foreach (SwordPartSO SO in InGameData.swordParts)
        {
            Instantiate(SO.UIObject, swordPartsUIHolder);
        }
        foreach (ItemSO SO in InGameData.items)
        {
            ItemFieldUI itemFieldUI = Instantiate(itemsUIField, itemsUIHolder).GetComponent<ItemFieldUI>();
            itemFieldUI.itemSO = SO;
            itemFieldUI.SetVisual();
        }
    }

    public void AddSwordPart(SwordPartSO swordPartSO)
    {
        InGameData.AddSwordPart(swordPartSO);
        CreateUI();
    }
    public void AddItem(ItemSO itemSO)
    {
        InGameData.AddItem(itemSO);
        CreateUI();
    }
    public void PlayerJumpscare(Transform jumpscareCameraHolder, float moveCameraTime, float jumpscareDuration)
    {
        player.MoveAndDockCamera(jumpscareCameraHolder, moveCameraTime);
        SceneReload(jumpscareDuration, 1f);
    }

    public async void SceneReload(float waitDuration, float fadeDuration)
    {
        StartCoroutine(screenFade.FadeIn(fadeDuration, waitDuration));
        await Task.Delay((int)(waitDuration * 1000) + (int)(fadeDuration * 1000));
        Loader.Load(scene);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateUI();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuGameObject.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}
