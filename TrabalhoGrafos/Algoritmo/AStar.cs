using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Interface;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos.Algoritmo
{
    public class AStar : IShortest
    {
        private Graph graph;

        private List<Node> OpenedList;

        private List<Node> ClosedList;

        private List<Node> ItemsList;

        public AStar(Graph graph)
        {
            OpenedList = new List<Node>();
            ClosedList = new List<Node>();
            ItemsList = new List<Node>();

            this.graph = graph;
        }

        public void ShortestWay2(string[] items)
        {
            Node actualNode = null;

            OpenedList.Add(graph.StarNode);

            ItemsList.Add(graph.StarNode);

            actualNode = graph.StarNode;

            for (int i = 0; i < items.Length; i++)
            {
                if (i > 0)
                {
                    ClosedList.Clear();
                    OpenedList.Clear();
                    OpenedList.Add(actualNode);
                    actualNode.CalculedCost = 0;
                    actualNode.MovedCost = 0;
                    ItemsList.Add(actualNode);
                }
                while (!actualNode.NameNode.Equals(items[i]))
                {

                    actualNode = OpenedList.OrderBy(x => x.CalculedCost).ToList()[0];
                    ClosedList.Add(actualNode);
                    OpenedList.Remove(actualNode);


                    actualNode.Vertices.FindAll(x => x.IsBackWay == false).ForEach(x =>
                    {
                        var neighbor = x.NodeTO;
                        if (OpenedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null )
                        {
                            if (ClosedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null && ItemsList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null)
                            {
                                neighbor.MovedCost = x.Cost;
                                neighbor.PrevNode = actualNode;
                                neighbor.CalculedCost = neighbor.PrevNode.MovedCost + x.Cost + CalculeH(neighbor, 0, items[i]);
                                OpenedList.Add(neighbor);
                            }
                        }
                        else
                        {
                            int CostNodePrevToActual = actualNode.MovedCost;
                            int CostNodePrevToNeighbor = neighbor.MovedCost;

                            if ((CostNodePrevToActual + x.Cost) < CostNodePrevToNeighbor)
                            {
                                neighbor.MovedCost = CostNodePrevToActual + CostNodePrevToNeighbor;
                                neighbor.PrevNode = actualNode;
                                neighbor.CalculedCost = neighbor.MovedCost + CalculeH(neighbor, 0, items[i]);
                            }
                        }
                    });
                }
            }
            
            

            Console.WriteLine(printGraph(graph.EndNode, "") + "AStars");      
        }

        public int CalculeH(Node node, int manhatan, string fim)
        {

            if (node.NameNode.Equals(fim))
                return 1;
            var nodeOnlyFrontWay = node.Vertices.FindAll(x => (x.IsBackWay == false) || x.NodeTO.NameNode.Equals(fim));
            if (nodeOnlyFrontWay.Count > 0)
            {
                foreach (var item in node.Vertices)
                {
                    manhatan += CalculeH(item.NodeTO, manhatan, fim);
                }
            }
            else
            {
                return 0;
            }
            return manhatan;
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
            throw new NotImplementedException();
        }
    }
}
