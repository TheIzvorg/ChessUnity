using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    void Start()
    {
        createField();
    }
    [SerializeField]
    private GameObject brick;
    [SerializeField]
    private GameObject[] chessArray;
    private ChessFigure[,] field;
    private void createField()
    {
        /*ChessField chessField = new ChessField();
        chessField.fillField();
        var field = chessField.Field;
        var chessName = field[0,0].pieceType + "_" + field[0, 0].pieceColor;*/
        field = new ChessFigure[8, 8];
        string str = field[0, 0].name;
        GameObject newBrick = brick;
        if(chessArray.Length != 0)
            Debug.Log(chessArray[0].name);
        Color color;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                int rgb = (i + j) % 2;
                color = new Color(rgb, rgb, rgb);
                newBrick.GetComponent<SpriteRenderer>().color = color;
                newBrick.transform.position = new Vector3(i, j);

                string chessName = "pawn_black";
                chessName = field[i, j].name + "_" + (field[i, j].isWhite ? "white" : "black");
                GameObject chess = Array.Find(chessArray, item => item.name == chessName);
                chess.transform.position = new Vector3(i, j);
                chess.transform.localScale = new Vector3(0.2f,0.2f,1);
                chess.GetComponent<SpriteRenderer>().sortingOrder = 1;

                Instantiate(newBrick);
                Instantiate(chess);
            }
        }
    }
}
