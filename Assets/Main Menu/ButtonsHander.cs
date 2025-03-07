using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class ButtonsHander : MonoBehaviour
{

public void New_Game()
    {

        SceneManager.LoadScene("ForestScene");
    }
    public void back_to_menu()
    {

        SceneManager.LoadScene("Main Menu");
    }
    public void credits()
    {

        SceneManager.LoadScene("Credits");
    }
    public void QuitGame()
    {
        Application.Quit();
        print("closed game");
            }

}
