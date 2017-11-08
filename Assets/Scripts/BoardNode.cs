using UnityEngine;
using System.Collections;

namespace AISandbox
{
    public class BoardNode
    {
        public BoardPosition pos;
        public int row;
        public int col;

        public BoardNode(int r, int c, BoardPosition p = BoardPosition.Empty)
        {
            pos = p;
            row = r;
            col = c;
        }
    }
}