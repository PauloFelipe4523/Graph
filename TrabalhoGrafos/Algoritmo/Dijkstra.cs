using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos.Algoritmo
{
    public class Dijkstra
    {
        private List<Node> UnvisitedNodes;

        public Dijkstra()
        {
            AllNodes.AllsNodes.ForEach(x =>
            {
                x.CalculedCost = x.NameNode.Equals("inicio") ? 0 : 999;
                UnvisitedNodes.Add(x);
            });
            UnvisitedNodes = UnvisitedNodes.OrderBy(x => x.CalculedCost).ToList();
        }

        public void ShortestWay()
        {
            while(UnvisitedNodes.Count > 0)
            {

            }
        }
    }
}
