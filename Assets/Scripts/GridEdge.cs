using UnityEngine;
using System;
using System.Collections;

namespace AISandbox
{
    public class GridEdge : IComparable
    {
        public GridNode parent;
        public GridNode node;

        public float cost;

        public int CompareTo(System.Object obj)
        {
            if (obj == null) return 1;

            GridEdge otherEdge = obj as GridEdge;
            if (otherEdge != null)
                return this.cost.CompareTo(otherEdge.cost);
            else
                throw new ArgumentException("Object is not a cost");
        }

        public GridEdge(GridNode node, GridNode parent, float cost)
        {
            this.cost = cost;
            this.node = node;
            this.parent = parent;
        }
    }
}