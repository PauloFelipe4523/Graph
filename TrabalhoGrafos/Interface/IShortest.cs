using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoGrafos.Models;

namespace TrabalhoGrafos.Interface
{
    public interface IShortest
    {
        void ShortestWay();
        string printGraph(Node node, string resultado);

    }
}
