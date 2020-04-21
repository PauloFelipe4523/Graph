using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos.Models
{
    public class Graph
    {
        public Node StarNode { get; private set; }

        public Node EndNode { get; private set; }

        public Graph(Node start, Node End)
        {
            this.StarNode = start;
            this.EndNode = End;
        }
    }
}
