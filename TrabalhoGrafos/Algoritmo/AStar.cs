using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos.Algoritmo
{
    public class AStar
    {
        private Graph graph;

        private List<Node> OpenedList;

        private List<Node> ClosedList;

        public AStar(Graph graph)
        {
            OpenedList = new List<Node>();
            ClosedList = new List<Node>();
            this.graph = graph;
        }

        public void ShortestWay()
        {
            Node actualNode = null;

            OpenedList.Add(graph.StarNode);

            actualNode = graph.StarNode;

            
            while (!actualNode.NameNode.Equals("fim"))
            {

                actualNode = OpenedList.OrderBy(x => x.CalculedCost).ToList()[0];
                ClosedList.Add(actualNode);
                OpenedList.Remove(actualNode);

                actualNode.Vertices.ForEach(x =>
                {
                    var neighbor = x.NodeTO;
                    if (OpenedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null)
                    {
                        if (ClosedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null)
                        {
                            neighbor.CalculedCost = actualNode.CalculedCost + x.Cost + CalculeH(neighbor, 0);
                            neighbor.Prev = actualNode;
                            OpenedList.Add(neighbor);
                        }                        
                    }
                    else
                    {
                        int CostNodePrevToActual = actualNode.Prev.Vertices.Find(prev => prev.NodeTO.NameNode.Equals(actualNode.NameNode)).Cost;
                        int CostNodePrevToNeighbor = neighbor.Prev.Vertices.Find(prev => prev.NodeTO.NameNode.Equals(neighbor.NameNode)).Cost;
                        
                        if ((CostNodePrevToActual + x.Cost) < CostNodePrevToNeighbor)
                        {
                            neighbor.Prev = actualNode;
                            neighbor.CalculedCost = CostNodePrevToActual + actualNode.Vertices.Find(prev => prev.NodeTO.NameNode.Equals(neighbor.NameNode)).Cost + CalculeH(neighbor, 0);
                        }
                    }                 
                });
            }

            Console.WriteLine(printGraph(graph.EndNode, ""));      
        }

        public int CalculeH(Node node, int manhatan)
        {
            var nodeOnlyFrontWay = node.Vertices.FindAll(x => x.IsBackWay == false);
            if (!node.NameNode.Equals("fim"))
            {
                manhatan = CalculeH(nodeOnlyFrontWay[0].NodeTO, ++manhatan);
            }
            return manhatan;
        }

        public string printGraph(Node node, string resultado)
        {
            if (!"inicio".Equals(node.NameNode))
            {
               resultado += printGraph(node.Prev, resultado);
            }
            resultado += node.NameNode + " => ";
            return resultado;
        }
    }
}
