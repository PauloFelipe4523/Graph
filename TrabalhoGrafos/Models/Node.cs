using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoGrafos.Models
{
    public class Node
    {
        private bool nested;

        public int CalculedCost { get; set; }
        public string NameNode { get; private set; }
        public bool IsToGet { get; private set; }

        public int MovedCost { get; set; }

        public List<Vertice> Vertices { get; private set; }

        public Node PrevNode { get; set; }

        public Node(bool isToGet, string name)
        {
            nested = false;
            this.NameNode = name;
            this.IsToGet = IsToGet;
            Vertices = new List<Vertice>();
            AllNodes.AllsNodes.Add(this);
        }

        public void AddVertices(Node to, int cost)
        {
            Vertices.Add(new Vertice(this, to, cost));
            if (!nested)
            {
                to.nested = true;
                to.AddBackVertice(this, cost);
            }
            Vertices = Vertices.OrderBy(x => x.Cost).ToList();
        }

        public void AddBackVertice(Node to, int cost)
        {
            Vertices.Add(new Vertice(this, to, cost, true));
            nested = false;
        }

        public override string ToString()
        {
            return NameNode;
        }
    }
}
