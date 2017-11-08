using UnityEngine;
using System.Collections.Generic;

namespace AISandbox
{
    public class GridNode : MonoBehaviour
    {
        public Grid grid;
        public int column;
        public int row;
        private BoardPosition pos;

        private SpriteRenderer _renderer;
        private Color _orig_color;
        private Color _p1_color;
        private Color _p2_color;

        public void ResetNode()
        {
            pos = BoardPosition.Empty;
            _renderer.color = _orig_color;
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _orig_color = _renderer.color;
            _p2_color = new Color(1, 0, 0);
            _p1_color = new Color(0, 1, 0);
        }

        public void SetPos(BoardPosition p)
        {
            pos = p;
            if (p == BoardPosition.Empty)
                _renderer.color = _orig_color;
            else if (p == BoardPosition.Green)
                _renderer.color = _p1_color;
            else if (p == BoardPosition.Red)
                _renderer.color = _p2_color;
        }

        public BoardPosition GetPos()
        {
            return pos;
        }

        public IList<GridNode> GetNeighbors(bool include_diagonal = false)
        {
            return grid.GetNodeNeighbors(row, column, include_diagonal);
        }
    }
}