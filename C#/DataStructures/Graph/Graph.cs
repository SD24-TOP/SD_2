using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Graph
{
    public class Graph
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int VerticesCount{ get; set; }
        public List<Edge> Edges { get; set; } = [];
        public List<Vertex> Vertices { get; set; } = [];
        public List<List<int>> DestMatrix { get; set; } = [[]];
        public bool IsOriented { get; set; } = false;
        public bool IsWeighted { get; set; } = false;
        public bool IsFull { get; set; } = true;


        public Graph(List<List<int>> matrix)
        {
            DestMatrix = matrix;
            VerticesCount = matrix.Count;
            for (int i = 0; i < VerticesCount; i++)
            {
                Vertices.Add(new Vertex(Convert.ToString(alphabet[i])));
            }

            for (int i = 0; i < VerticesCount; i++)
            {
                for (int j = 0; j < VerticesCount; j++)
                {
                    if (matrix[i][j] != 0)
                    {
                        if (i == j)
                        {
                            IsOriented = true;
                        }
                        if (matrix[i][j] != 1)
                        {
                            IsWeighted = true;
                        }

                        Edges.Add(new Edge(
                            Vertices[i],
                            Vertices[j],
                            matrix[i][j]));

                    }
                    else
                    {
                        if (i != j)
                        {
                            IsFull = false;
                        }
                    }
                }
            }

            IsOriented = IsOriented?true:!CheckSymetria();
        }
        private bool CheckSymetria()
        {
            for (int i = 1; i < VerticesCount; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (DestMatrix[i][j] != DestMatrix[j][i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
