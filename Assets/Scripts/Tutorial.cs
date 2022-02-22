using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    // Ограничение 100 символов
    [SerializeField] private Text tipText;
    [SerializeField] private Image mainImage;
    #region [SerializeField] private List<Sprite> sprites;
    /// <summary>
    /// 0 - PawnSprite,
    /// 1 - RookSprite,
    /// 2 - KnightSprite,
    /// 3 - BishopSprite,
    /// 4 - QueenSprite,
    /// 5 - KingSprite,
    /// </summary>
    [SerializeField] private List<Sprite> sprites;
    #endregion
    public void CloseTutorial()
    {
        this.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TutorialPawn()
    {
        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[0];
        ReadTutorialText("pawn");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 32;
    }

    public void TutorialQueen()
    {

        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[4];
        ReadTutorialText("queen");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 32;
    }

    public void TutorialRook()
    {

        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[1];
        ReadTutorialText("rook");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 32;
    }

    public void TutorialKnight()
    {

        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[2];
        ReadTutorialText("knight");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 32;
    }

    public void TutorialKing()
    {
        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[5];
        ReadTutorialText("king");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 26;
    }

    public void TutorialBishop()
    {
        this.gameObject.SetActive(true);
        mainImage.sprite = sprites[3];
        ReadTutorialText("bishop");
        mainImage.color = new Color(255, 255, 255, 255);
        tipText.fontSize = 32;
    }

    public void TutorialGeneral()
    {
        this.gameObject.SetActive(true);
        ReadTutorialText("general");
        mainImage.color = new Color(255, 255, 255, 0);
        tipText.fontSize = 32;
    }

    private void Start()
    {
        this.gameObject.SetActive(false);
        Debug.Log(Application.persistentDataPath);

        //ShowTip();
        // TODO: Появление интерфейса обучения
        // Несколько стадий обучения. Как минимум 1 стадия на 1 тип фигур
        // Показать как ходят разные фигуры.
        // Показать как сделать Шах и Мат.
    }

    private void ReadTutorialText(string fileName)
    {
        tipText.text = "";
        string path = $"Assets/Text/{fileName}.txt";
        StreamReader reader = new StreamReader(path);
        string buff;
        while ((buff = reader.ReadLine()) != null)
        {
            tipText.text += buff + "\n";
        }
        reader.Close();
    }
}
