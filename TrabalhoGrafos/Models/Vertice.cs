using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos.Models
{
    public class Vertice
    {
        public int Cost { get; private set; }

        public Node NodeTO { get; private set; }

        public Node NodeFrom { get; private set; }

        public Vertice(Node from, Node to, int cost)
        {
            this.NodeTO = to;
            this.NodeFrom = from;
            this.Cost = cost;
        }

        public override string ToString()
        {
            return string.Format("From Node {0} To Node {1} Cost {2}", NodeFrom, NodeTO, Cost);
        }
    }
}
