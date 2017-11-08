using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AISandbox
{
    public class Board
    {
        public BoardNode[,] nodes;
        int gridsize;

        public bool GameOver()
        {
            foreach(BoardNode n in nodes)
            {
                if (n.pos == BoardPosition.Empty)
                    return false;
            }
            return true;
        }

        public IList<BoardNode> GetPossibleMoves()
        {
            IList<BoardNode> list = new List<BoardNode>();

            for (int row = 0; row < gridsize; ++row)
            {
                for (int col = 0; col < gridsize; ++col)
                {
                    if (nodes[row, col].pos == BoardPosition.Empty)
                        list.Add(nodes[row, col]);
                }
            }
            return list;
        }

        public Board MakeMove(BoardNode n, bool AIChance)
        {
            Board newBoard = new Board(nodes, gridsize);

            //Board newBoard = (Board)this.MemberwiseClone();
            //newBoard.nodes = new BoardNode[gridsize, gridsize];

            //for (int row = 0; row < gridsize; ++row)
            //{
            //    for (int col = 0; col < gridsize; ++col)
            //    {
            //        newBoard.nodes[row, col] = new Board(row, col, );
            //    }
            //}

            if (AIChance)
                newBoard.nodes[n.row,n.col].pos = BoardPosition.Red;
            else
                newBoard.nodes[n.row, n.col].pos = BoardPosition.Green;

            return newBoard;
        }

        public int Evaluate(bool AIturn)
        {
            int scoreRed = 0;
            int scoreGreen = 0;

            // for rows
            for (int i = 0; i < gridsize; i++)
            {
                int winRed = 0;
                int winGreen = 0;
                for (int j = 0; j < gridsize; j++)
                {
                    //red
                    if (nodes[i, j].pos == BoardPosition.Red)
                        winRed++;
                    else
                        winRed = 0;

                    if (winRed >= 2)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 3)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 4)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 5)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 6)
                        scoreRed = scoreRed + 1;

                    //green
                    if (nodes[i, j].pos == BoardPosition.Green)
                        winGreen++;
                    else
                        winGreen = 0;

                    if (winGreen >= 2)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 3)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 4)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 5)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 6)
                        scoreGreen = scoreGreen + 1;
                }
            }

            // for columns
            for (int i = 0; i < gridsize; i++)
            {
                int winRed = 0;
                int winGreen = 0;
                for (int j = 0; j < gridsize; j++)
                {
                    //red
                    if (nodes[j, i].pos == BoardPosition.Red)
                        winRed++;
                    else
                        winRed = 0;

                    if (winRed >= 2)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 3)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 4)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 5)
                        scoreRed = scoreRed + 1;
                    if (winRed >= 6)
                        scoreRed = scoreRed + 1;

                    //green
                    if (nodes[j, i].pos == BoardPosition.Green)
                        winGreen++;
                    else
                        winGreen = 0;

                    if (winGreen >= 2)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 3)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 4)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 5)
                        scoreGreen = scoreGreen + 1;
                    if (winGreen >= 6)
                        scoreGreen = scoreGreen + 1;
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
                        if (nodes[k, l].pos == BoardPosition.Red)
                            winRed++;
                        else
                            winRed = 0;

                        if (winRed >= 2)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 3)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 4)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 5)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 6)
                            scoreRed = scoreRed + 1;

                        //green
                        if (nodes[k, l].pos == BoardPosition.Green)
                            winGreen++;
                        else
                            winGreen = 0;

                        if (winGreen >= 2)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 3)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 4)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 5)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 6)
                            scoreGreen = scoreGreen + 1;

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
                        if (nodes[l, k].pos == BoardPosition.Red)
                            winRed++;
                        else
                            winRed = 0;

                        if (winRed >= 2)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 3)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 4)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 5)
                            scoreRed = scoreRed + 1;
                        if (winRed >= 6)
                            scoreRed = scoreRed + 1;

                        //green
                        if (nodes[l, k].pos == BoardPosition.Green)
                            winGreen++;
                        else
                            winGreen = 0;

                        if (winGreen >= 2)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 3)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 4)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 5)
                            scoreGreen = scoreGreen + 1;
                        if (winGreen >= 6)
                            scoreGreen = scoreGreen + 1;

                        k--;
                        l++;
                    }
                }
            }

            return (scoreRed - scoreGreen);
            //if (AIturn)
            //    return finalScore;
            //else
            //    return -finalScore;
        }

        public void UpdateBoard(BoardNode n)
        {
            nodes[n.row, n.col].pos = BoardPosition.Red;
        }

        public void UpdateBoard(GridNode n)
        {
            nodes[n.row, n.column].pos = n.GetPos();
        }

        public Board(GridNode[,] grids, int size)
        {
            gridsize = size;
            nodes = new BoardNode[gridsize, gridsize];

            for (int row = 0; row < gridsize; ++row)
            {
                for (int col = 0; col < gridsize; ++col)
                {
                    nodes[row, col] = new BoardNode(row, col, grids[row, col].GetPos());
                }
            }
        }

        public Board(BoardNode[,] grids, int size)
        {
            gridsize = size;
            nodes = new BoardNode[gridsize, gridsize];

            for (int row = 0; row < gridsize; ++row)
            {
                for (int col = 0; col < gridsize; ++col)
                {
                    nodes[row, col] = new BoardNode(row, col, grids[row, col].pos);
                }
            }
        }
    }
}