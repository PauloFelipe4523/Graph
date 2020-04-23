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
        // Grafo a ser processado
        private Graph graph;

        //lista aberta 
        private List<Node> OpenedList;

        //lista fechada
        private List<Node> ClosedList;

        //construtor recebe a estrutura de grafo para encontrar o menor caminho
        public AStar(Graph graph)
        {
            OpenedList = new List<Node>();
            ClosedList = new List<Node>();

            this.graph = graph;
        }

        // metodo para encontrar o menor caminho, o algoritmo A* inicia a lista aberta com o nó inicial e aponta ele como nó atual,
        // depois entra no loop até que o nó de destino não seja o nó atual, ele ordena a lista aberta pelo menor custo e seta no nó atual, em seguida
        // remove da lista aberta o nó atual. Para o nó atual ele checa cada vertice recuperando seus vizinhos. se o nó vizinho não estiver na lista 
        // aberta ele verifica se não esta na lista fechada, caso nao estiver ele calcula o custo do nó pai até chegar ao nó filho e soma a função
        // de heuristica e adiciona o vizinho atual à lista aberta. caso o vizinho atual ja esteja na lista aberta
        public void ShortestWay()
        {
            Node actualNode = null;

            OpenedList.Add(graph.StarNode);

            actualNode = graph.StarNode;

            while (!actualNode.NameNode.Equals(graph.EndNode.NameNode))
            {

                actualNode = OpenedList.OrderBy(x => x.CalculedCost).ToList()[0];
                ClosedList.Add(actualNode);
                OpenedList.Remove(actualNode);


                actualNode.Vertices.FindAll(x => x.IsBackWay == false).ForEach(x =>
                {
                    var neighbor = x.NodeTO;
                    if (OpenedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null )
                    {
                        if (ClosedList.Find(y => y.NameNode.Equals(neighbor.NameNode)) == null)
                        {
                            neighbor.MovedCost = x.Cost;
                            neighbor.PrevNode = actualNode;
                            neighbor.CalculedCost = neighbor.PrevNode.MovedCost + x.Cost + CalculeH(neighbor, 0);
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
                            neighbor.CalculedCost = neighbor.MovedCost + CalculeH(neighbor, 0);
                        }
                    }
                });
            }

            Console.WriteLine(printGraph(graph.EndNode, "") + "AStars");      
        }

        public int CalculeH(Node node, int manhattan)
        {

            var nodeOnlyFrontWay = node.Vertices.FindAll(x => (x.IsBackWay == false && x.Cost == 3) || x.NodeTO.NameNode.Equals("fim"));
            if (nodeOnlyFrontWay.Count > 0)
            {
                manhattan = CalculeH(nodeOnlyFrontWay[0].NodeTO, ++manhattan);
            }
            return manhattan;
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
    }
}
