using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ButtonsHander : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;

    [SerializeField] SongSO mainMenuSong;
    public void NewGame()
    {
        MusicManager.Instance.StopSong(mainMenuSong, 0.5f);
        SceneManager.LoadScene("ForestScene");
    }
    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void ToCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
        MusicManager.Instance.StopSong(mainMenuSong, 2f);
    }

    private void Start()
    {
        MusicManager.Instance.PlaySong(mainMenuSong, 0f);
    }

}
