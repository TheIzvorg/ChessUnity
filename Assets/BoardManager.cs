using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; set; }
    private bool[,] allowedMoves { get; set; }

    public ChessFigure[,] ChessFigurePositions { get; set; }
    private ChessFigure selectedFigure;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;
    private int selectionX = -1;
    private int selectionY = -1;

    [SerializeField]
    private List<GameObject> chessFigures;
    private List<GameObject> activeFigures = new List<GameObject>();

    private ChessAI ai;

    public bool isWhiteTurn = true;

    void Start()
    {
        Instance = this;
        
        ai = new ChessAI();

        ChessFigurePositions = new ChessFigure[8, 8];

        SpawnAllChessFigures();
    }

    void Update()
    {
        UpdateSelection();

        if(Input.GetMouseButtonDown(0))
        {
            if(selectionX >= 0 && selectionY >= 0)
            {
                if(selectedFigure == null)
                {
                    SelectChessFigure(selectionX, selectionY);
                }
                else
                {
                    MoveChessFigure(selectionX, selectionY);
                }
            }
        }

        if (!isWhiteTurn && Settings.IsSinglePlayer)
        {
            Vector2 aiMove = new Vector2();
            do
            {
                selectedFigure = ai.SelectChessFigure();
                aiMove = ai.MakeMove(selectedFigure);
            } while (aiMove.x < 0 && aiMove.y < 0);

            allowedMoves = ChessFigurePositions[selectedFigure.CurrentX, selectedFigure.CurrentY].PossibleMove();
            MoveChessFigure((int)Math.Round(aiMove.x), (int)Math.Round(aiMove.y));
        } 
    }

    private void SelectChessFigure(int x, int y)
    {
        if (ChessFigurePositions[x, y] == null) return;
        if (ChessFigurePositions[x, y].isWhite != isWhiteTurn) return;

        bool hasAtLeastOneMove = false;
        allowedMoves = ChessFigurePositions[x, y].PossibleMove();

        foreach(bool item in allowedMoves)
        {
            if (item)
            {
                hasAtLeastOneMove = item;
                break;
            }
        }

        if (!hasAtLeastOneMove) return;

        selectedFigure = ChessFigurePositions[x, y];
        BoardHighlighting.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveChessFigure(int x, int y)
    {
        if(allowedMoves[x,y])
        {
            ChessFigure c = ChessFigurePositions[x, y];
            if(c != null && c.isWhite != isWhiteTurn)
            {
                activeFigures.Remove(c.gameObject);
                Destroy(c.gameObject);

                if(c.GetType() == typeof(King))
                {
                    EndGame();
                    return;
                }
            }

            ChessFigurePositions[selectedFigure.CurrentX, selectedFigure.CurrentY] = null;
            selectedFigure.transform.position = new Vector3(x,y);
            selectedFigure.SetPosition(x, y);
            ChessFigurePositions[x, y] = selectedFigure;
            isWhiteTurn = !isWhiteTurn;

            if (selectedFigure.GetType() == typeof(Pawn) && y == 7 * (selectedFigure.isWhite ? 1:0 ))
            {
                activeFigures.Remove(selectedFigure.gameObject);
                Destroy(selectedFigure.gameObject);
                SpawnChessFigure(1 + (6*(selectedFigure.isWhite ? 0:1)), x, y);
            }
        }

        BoardHighlighting.Instance.HideHighlights();

        selectedFigure = null;
    }
    private void UpdateSelection()
    {
        if (!Camera.main) return;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        if (mouseWorldPos.x >= 0 && mouseWorldPos.y >= 0)
        {
            selectionX = (int)Math.Round(mouseWorldPos.x);
            selectionY = (int)Math.Round(mouseWorldPos.y);
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnChessFigure(int index, int x, int y)
    {
        GameObject go = Instantiate(chessFigures[index], new Vector3(x,y), chessFigures[index].transform.rotation) as GameObject;
        go.transform.SetParent(transform);
        ChessFigurePositions[x, y] = go.GetComponent<ChessFigure>();
        ChessFigurePositions[x, y].SetPosition(x, y);
        activeFigures.Add(go);
    }

    private void SpawnAllChessFigures()
    {
        // White
        SpawnChessFigure(0, 4, 0); // King
        SpawnChessFigure(1, 3, 0); // Queen
        SpawnChessFigure(2, 0, 0); // Rook
        SpawnChessFigure(2, 7, 0); // Rook
        SpawnChessFigure(3, 2, 0); // Bishop
        SpawnChessFigure(3, 5, 0); // Bishop
        SpawnChessFigure(4, 1, 0); // Knight
        SpawnChessFigure(4, 6, 0); // Knight
        SpawnChessFigure(5, 0, 1);
        SpawnChessFigure(5, 1, 1);
        SpawnChessFigure(5, 2, 1);
        SpawnChessFigure(5, 3, 1);
        SpawnChessFigure(5, 4, 1);
        SpawnChessFigure(5, 5, 1);
        SpawnChessFigure(5, 6, 1);
        SpawnChessFigure(5, 7, 1);

        // Black
        SpawnChessFigure(6, 4, 7); // King
        SpawnChessFigure(7, 3, 7); // Queen
        SpawnChessFigure(8, 0, 7); // Rook
        SpawnChessFigure(8, 7, 7); // Rook
        SpawnChessFigure(9, 2, 7); // Bishop
        SpawnChessFigure(9, 5, 7); // Bishop
        SpawnChessFigure(10, 1, 7); // Knight
        SpawnChessFigure(10, 6, 7); // Knight
        SpawnChessFigure(11, 0, 6);
        SpawnChessFigure(11, 1, 6);
        SpawnChessFigure(11, 2, 6);
        SpawnChessFigure(11, 3, 6);
        SpawnChessFigure(11, 4, 6);
        SpawnChessFigure(11, 5, 6);
        SpawnChessFigure(11, 6, 6);
        SpawnChessFigure(11, 7, 6);
    }

    private void EndGame()
    {
        activeFigures.Clear();
        GameObject[] go2 = GameObject.FindGameObjectsWithTag("Chess");

        foreach (GameObject item in go2)
            Destroy(item);

        isWhiteTurn = true;
        BoardHighlighting.Instance.HideHighlights();
        SpawnAllChessFigures();
    }

    public List<GameObject> GetAllActiveFigures()
    {
        return activeFigures;
    }
}
