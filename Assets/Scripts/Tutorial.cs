using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // ����������� 100 ��������
    [SerializeField] Text test;

    [SerializeField] private bool isPause = false;
    [SerializeField] private GameObject pauseMenu;
    async void Start()
    {
        isPause = false;

        test.text = "����� ���������� � �������!";

        //ShowTip();
        // TODO: ��������� ���������� ��������
        // ��������� ������ ��������. ��� ������� 1 ������ �� 1 ��� �����
        // �������� ��� ����� ������ ������.
        // �������� ��� ������� ��� � ���.
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
