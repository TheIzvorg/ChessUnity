using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Ограничение 100 символов
    [SerializeField] Text test;

    [SerializeField] private bool isPause = false;
    [SerializeField] private GameObject pauseMenu;
    async void Start()
    {
        isPause = false;

        test.text = "Добро пожаловать в Шахматы!";

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
    }

    public void PauseGame()
    {
        isPause = true;
        pauseMenu.SetActive(true);
    }

    public void ShowTip()
    {

    }
}
