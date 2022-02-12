using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(800, 600, FullScreenMode.Windowed, 30);
    }

    public static void StartGame(bool IsSinglePlayer)
    {
        Settings.IsSinglePlayer = IsSinglePlayer;
        SceneManager.LoadScene(1);
    }

    public static void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
     
    public static void ExitGame()
    {
        Application.Quit();
    }
}
