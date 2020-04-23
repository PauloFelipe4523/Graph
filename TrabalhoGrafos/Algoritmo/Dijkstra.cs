using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Interface;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos.Algoritmo
{
    public class Dijkstra : IShortest
    {
        private List<Node> UnvisitedNodes;

        private List<Node> CostNodes;

        private Graph Graph;

        public Dijkstra(Graph graph)
        {
            this.Graph = graph;
            UnvisitedNodes = new List<Node>();
            CostNodes = new List<Node>();
            AllNodes.AllsNodes.ForEach(x =>
            {
                x.CalculedCost = x.NameNode.Equals("inicio") ? 0 : 999;
                UnvisitedNodes.Add(x);
                CostNodes.Add(x);
            });
            UnvisitedNodes = UnvisitedNodes.OrderBy(x => x.CalculedCost).ToList();
            CostNodes = CostNodes.OrderBy(x => x.CalculedCost).ToList();
        }

        public string printGraph(Node node, string resultado)
        {
            if (!"inicio".Equals(node.NameNode))
            {
                resultado += printGraph(node.PrevNode, resultado);
            }
            resultado += node.NameNode + " => ";
            return resultado;
        }

        public void ShortestWay()
        {
            Node prev = null;
            while(UnvisitedNodes.Count > 0)
            {
                UnvisitedNodes = UnvisitedNodes.OrderBy(x => x.CalculedCost).ToList();
                Node shortestCost = UnvisitedNodes[0];
                UnvisitedNodes.Remove(shortestCost);
                shortestCost.Vertices.ForEach(x =>
                {
                    int totalCost = GetCost(shortestCost, x);
                    if (totalCost < x.NodeTO.CalculedCost)
                    {
                        x.NodeTO.CalculedCost = totalCost;
                        x.NodeTO.PrevNode = x.NodeFrom;
                        prev = x.NodeFrom;
                    }                    
                });
                if (shortestCost.NameNode.Equals(this.Graph.EndNode.NameNode))
                {
                    this.Graph.EndNode.PrevNode = prev;
                }
            }
            Console.WriteLine(printGraph(this.Graph.EndNode, "") + "Dijkstra");
        }

        private int GetCost(Node node, Vertice vertice)
        {
            return vertice.Cost + node.CalculedCost;
        }
    }
}
