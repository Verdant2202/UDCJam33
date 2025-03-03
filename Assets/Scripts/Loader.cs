using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        VoidScene,
        ForestScene,
    }

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
