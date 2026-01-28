using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Vertex(string name)
    {
        public string Name { get; set; } = name;
        public override string ToString()
        {
            return Name;
        }
        public override bool Equals(object? obj)
        {
            return this.Name == ((Vertex)obj).Name;
        }
    }
}
