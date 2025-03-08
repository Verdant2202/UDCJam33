using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPauseManager : MonoBehaviour
{
    [SerializeField] ForestPlayer player;
    [SerializeField] GameObject pauseMenuGameObject;
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


    public void PauseQuit()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        Loader.Load(Loader.Scene.MainMenu);
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuGameObject.activeSelf)
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
