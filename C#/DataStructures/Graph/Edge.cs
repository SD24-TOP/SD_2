using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Edge(Vertex from, Vertex to, int weight = 1)
    {
        public Vertex From { get; set; } = from;
        public Vertex To { get; set; } = to;
        public int Weight { get; set; } = weight;
    }
}
