using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Algoritmo;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos
{
    class Program
    {
        static void Main(string[] args)
        {

            AllNodes.AllsNodes = new List<Node>();
            Graph graph = new Graph(new Node(false, "inicio"), new Node(false, "fim"));

            graph.StarNode.AddVertices(new Node(false, "01"), 8);
            graph.StarNode.AddVertices(new Node(false, "02"), 5);
            graph.StarNode.AddVertices(new Node(true, "03"), 6);
            graph.StarNode.AddVertices(new Node(false, "04"), 8);

            //nó 01
            var node_01 = graph.StarNode.Vertices.Find(x => x.NodeTO.NameNode.Equals("01")).NodeTO;
            node_01.AddVertices(new Node(true, "05"), 3);
            node_01.AddVertices(new Node(false, "06"), 4);
            node_01.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("02")), 2);

            //nó 02
            var node_02 = graph.StarNode.Vertices.Find(x => x.NodeTO.NameNode.Equals("02")).NodeTO;
            node_02.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("05")), 4);
            node_02.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("06")), 3);
            node_02.AddVertices(new Node(true, "07"), 4);
            node_02.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("01")), 2);
            node_02.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("03")), 2);

            //nó 03
            var node_03 = graph.StarNode.Vertices.Find(x => x.NodeTO.NameNode.Equals("03")).NodeTO;
            node_03.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("06")), 4);
            node_03.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("07")), 3);
            node_03.AddVertices(new Node(true, "08"), 4);
            node_03.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("02")), 2);
            node_03.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("04")), 2);

            //nó 04
            var node_04 = graph.StarNode.Vertices.Find(x => x.NodeTO.NameNode.Equals("04")).NodeTO;
            node_04.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("07")), 4);
            node_04.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("08")), 3);
            node_04.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("03")), 2);

            //nó 05
            var node_05 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("05"));
            node_05.AddVertices(new Node(false, "09"), 3);
            node_05.AddVertices(new Node(false, "10"), 4);
            node_05.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("06")), 2);

            //nó 06
            var node_06 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("06"));
            node_06.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("09")), 4);
            node_06.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("10")), 3);
            node_06.AddVertices(new Node(false, "11"), 4);
            node_06.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("05")), 2);
            node_06.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("07")), 2);

            //nó 07
            var node_07 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("07"));
            node_07.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("10")), 4);
            node_07.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("11")), 3);
            node_07.AddVertices(new Node(true, "12"), 4);
            node_07.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("06")), 2);
            node_07.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("08")), 2);

            //nó 08
            var node_08 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("08"));
            node_08.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("11")), 4);
            node_08.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("12")), 3);
            node_08.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("07")), 2);

            //nó 09
            var node_09 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("09"));
            node_09.AddVertices(graph.EndNode, 7);
            node_09.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("10")), 2);

            //nó 10
            var node_10 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("10"));
            node_10.AddVertices(graph.EndNode, 17);
            node_10.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("09")), 2);
            node_10.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("11")), 2);

            //nó 11
            var node_11 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("11"));
            node_11.AddVertices(graph.EndNode, 7);
            node_11.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("10")), 2);
            node_11.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("12")), 2);

            //nó 12
            var node_12 = AllNodes.AllsNodes.Find(x => x.NameNode.Equals("12"));
            node_12.AddVertices(graph.EndNode, 7);
            node_12.AddVertices(AllNodes.AllsNodes.Find(x => x.NameNode.Equals("11")), 2);

            Dijkstra dijkstra = new Dijkstra(graph);


        }
    }
}
