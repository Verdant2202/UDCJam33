using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ButtonsHander : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;
    public void NewGame()
    {
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
        print("closed game");
    }

}
