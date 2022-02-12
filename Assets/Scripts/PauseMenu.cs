using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
        BoardManager.Instance.isPause = false;
    }

    public void RestartGame()
    {
        BoardManager.Instance.EndGame();
        pauseMenu.SetActive(false);
        BoardManager.Instance.isPause = false;
    }

    public void BackToMenu()
    {
        SceneChanger.BackToMenu();
    }
}
