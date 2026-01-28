using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures.Graph
{
    public class Edge(Vertex from, Vertex to, int weight = 1)
    {
        public Vertex From { get; set; } = from;
        public Vertex To { get; set; } = to;
        public int Weight { get; set; } = weight;

        public override string ToString()
        {
            return $"{From}-{To}";
        }
        public override bool Equals(object? obj)
        {
            return this.From == ((Edge)obj).From && this.To == ((Edge)obj).To && this.Weight == ((Edge)obj).Weight;
        }
    }
}
