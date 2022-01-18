using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void StartGame(bool IsSinglePlayer)
    {
        Settings.IsSinglePlayer = IsSinglePlayer;
        SceneManager.LoadScene(1);
    }
}
