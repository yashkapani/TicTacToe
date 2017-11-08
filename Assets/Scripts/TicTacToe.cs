using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace AISandbox
{
    public enum BoardPosition
    {
        Empty,
        Red,
        Green
    }

    public struct Result
    {
        public float score;
        public BoardNode move;

        public Result(float s, BoardNode m)
        {
            score = s;
            move = m;
        }
    }

    public class TicTacToe : MonoBehaviour
    {
        public Grid grid;
        public Board board;
        public Canvas ui;
        private Text uiScore;
        private Text uiRedScore;
        private Text uiGreenScore;
        private bool playerChance;
        private int depth;
        private int boardsize;
        private float score;

        public int redScore = 0;
        public int greenScore = 0;

        private void Start()
        {
            // Create and center the grid
            score = 0;
            boardsize = 6;
            depth = 4;
            grid.Create(boardsize, boardsize);
            Vector2 gridSize = grid.size;
            Vector2 gridPos = new Vector2(gridSize.x * -0.5f, gridSize.y * 0.5f);
            grid.transform.position = gridPos;

            playerChance = true;

            // set up the board
            board = new Board(grid._nodes, boardsize);
            uiScore = ui.GetComponentsInChildren<Text>()[0];
            uiRedScore = ui.GetComponentsInChildren<Text>()[2];
            uiGreenScore = ui.GetComponentsInChildren<Text>()[3];
        }

        private void Update()
        {
            if (playerChance)
                CheckMouseEvents();

            uiScore.text = "Cost: " + score.ToString();
            uiGreenScore.text = "Green: " + greenScore.ToString();
            uiRedScore.text = "Red: " + redScore.ToString();
        }

        private void PlayAI()
        {
            Result aiMove = MinMax(board, true, depth, 1);
            board.UpdateBoard(aiMove.move);
            grid._nodes[aiMove.move.row, aiMove.move.col].SetPos(BoardPosition.Red);
            Debug.Log(aiMove.score);
            score = aiMove.score;
            playerChance = true;
            GameScore();
        }

        public void Reset()
        {
            //startNode = null;
            //destinationNode = null;
            //grid.ResetGrid();
        }

        public void Quit()
        {
            Application.Quit();
        }

        private Result MinMax(Board b, bool AIChance, int maxDepth, int currentDepth)
        {
            if (b.GameOver() || currentDepth == maxDepth)
                return new Result(b.Evaluate(AIChance), null);

            Result bestResult;
            if (!AIChance)
                bestResult = new Result(Mathf.Infinity, null);
            else
                bestResult = new Result(Mathf.NegativeInfinity, null);

            IList<BoardNode> moves = b.GetPossibleMoves();

            foreach (BoardNode n in moves)
            {
                Board boardAfterMove = b.MakeMove(n, AIChance);
                Result currentResult = MinMax(boardAfterMove, !AIChance, maxDepth, currentDepth + 1);

                if (AIChance)
                {
                    if (currentResult.score > bestResult.score)
                    {
                        bestResult.score = currentResult.score;
                        bestResult.move = n;
                    }
                }
                else
                {
                    if (currentResult.score < bestResult.score)
                    {
                        bestResult = currentResult;
                        bestResult.move = n;
                    }
                }
            }

            return bestResult;
        }

        public void GameScore()
        {
            redScore = 0;
            greenScore = 0;

            for (int i = 0; i < boardsize; i++)
            {
                int winRed = 0;
                int winGreen = 0;
                for (int j = 0; j < boardsize; j++)
                {
                    //red
                    if (board.nodes[i, j].pos == BoardPosition.Red)
                        winRed++;
                    else
                        winRed = 0;

                    if (winRed >= 6)
                        redScore++;
                    else if (winRed >= 5)
                        redScore++;
                    else if (winRed >= 4)
                        redScore++;

                    //green
                    if (board.nodes[i, j].pos == BoardPosition.Green)
                        winGreen++;
                    else
                        winGreen = 0;

                    if (winGreen >= 6)
                        greenScore++;
                    else if (winGreen >= 5)
                        greenScore++;
                    else if (winGreen >= 4)
                        greenScore++;
                }
            }

            // for columns
            for (int i = 0; i < boardsize; i++)
            {
                int winRed = 0;
                int winGreen = 0;
                for (int j = 0; j < boardsize; j++)
                {
                    //red
                    if (board.nodes[j, i].pos == BoardPosition.Red)
                        winRed++;
                    else
                        winRed = 0;

                    if (winRed >= 6)
                        redScore++;
                    else if (winRed >= 5)
                        redScore++;
                    else if (winRed >= 4)
                        redScore++;

                    //green
                    if (board.nodes[j, i].pos == BoardPosition.Green)
                        winGreen++;
                    else
                        winGreen = 0;

                    if (winGreen >= 6)
                        greenScore++;
                    else if (winGreen >= 5)
                        greenScore++;
                    else if (winGreen >= 4)
                        greenScore++;
                }
            }

            {
                int k = 2;
                int l = 0;
                for (int z = 0; z < 5; z++)
                {
                    if (z < 3)
                    {
                        k = k + 1;
                    }
                    else
                    {
                        k = 5;
                        l = z - 2;
                    }

                    int winRed = 0;
                    int winGreen = 0;
                    while (k >= 0 && l <= 5)
                    {
                        //red
                        if (board.nodes[k, l].pos == BoardPosition.Red)
                            winRed++;
                        else
                            winRed = 0;

                        if (winRed >= 4)
                            redScore++;
                        if (winRed >= 5)
                            redScore++;
                        if (winRed >= 6)
                            redScore++;

                        //green
                        if (board.nodes[k, l].pos == BoardPosition.Green)
                            winGreen++;
                        else
                            winGreen = 0;

                        if (winGreen >= 4)
                            greenScore++;
                        if (winGreen >= 5)
                            greenScore++;
                        if (winGreen >= 6)
                            greenScore++;

                        k--;
                        l++;
                    }
                }
            }

            {
                int k = 2;
                int l = 0;
                for (int z = 0; z < 5; z++)
                {
                    if (z < 3)
                    {
                        k = k + 1;
                    }
                    else
                    {
                        k = 5;
                        l = z - 2;
                    }

                    int winRed = 0;
                    int winGreen = 0;
                    while (k >= 0 && l <= 5)
                    {
                        //red
                        if (board.nodes[l, k].pos == BoardPosition.Red)
                            winRed++;
                        else
                            winRed = 0;

                        if (winRed >= 4)
                            redScore++;
                        if (winRed >= 5)
                            redScore++;
                        if (winRed >= 6)
                            redScore++;

                        //green
                        if (board.nodes[l, k].pos == BoardPosition.Green)
                            winGreen++;
                        else
                            winGreen = 0;

                        if (winGreen >= 4)
                            greenScore++;
                        if (winGreen >= 5)
                            greenScore++;
                        if (winGreen >= 6)
                            greenScore++;

                        k--;
                        l++;
                    }
                }
            }
        }

        private void CheckMouseEvents()
        {
            if (Input.GetMouseButtonUp(0))
            {
                GridNode newNode = grid.MarkNode();
                if (newNode)
                {
                    playerChance = false;
                    board.UpdateBoard(newNode);
                    PlayAI();
                    GameScore();
                }
            }
        }
    }
}