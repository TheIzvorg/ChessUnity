using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Ограничение 100 символов
    [SerializeField] Text tipText;

    [SerializeField] private bool isPause = false;
    [SerializeField] private GameObject pauseMenu;

    private List<string> tutorialText;
    private int currTipId = 0;
    async void Start()
    {
        tutorialText = new List<string>();
        ReadTutorialText();
        ShowTip();

        //ShowTip();
        // TODO: Появление интерфейса обучения
        // Несколько стадий обучения. Как минимум 1 стадия на 1 тип фигур
        // Показать как ходят разные фигуры.
        // Показать как сделать Шах и Мат.
    }
    void Update()
    {
        if (isPause)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();

        if (Input.GetMouseButtonDown(0))
            ShowTip();
    }

    public void PauseGame()
    {
        isPause = true;
        pauseMenu.SetActive(true);
    }

    private void ReadTutorialText()
    {
        string path = "Assets/Text/tutorial.ini";
        StreamReader reader = new StreamReader(path);
        string buff;
        while ((buff = reader.ReadLine()) != null)
        {
            tutorialText.Add(buff);
        }
    }

    private void ShowTip()
    {
        tipText.text = tutorialText[currTipId++];
        currTipId = Mathf.Max(0, Mathf.Min(currTipId, tutorialText.Count - 1));
    }
}
