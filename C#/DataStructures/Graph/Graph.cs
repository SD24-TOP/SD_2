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
        public int VerticesCount { get; set; }
        public List<Edge> Edges { get; set; } = [];
        public List<Vertex> Vertices { get; set; } = [];
        public List<List<int>> DestMatrix { get; set; } = [[]];
        public Dictionary<Vertex, List<Vertex>> ListOfLinks { get; set; } = new Dictionary<Vertex, List<Vertex>>();
        public bool IsOriented { get; set; } = false;
        public bool IsWeighted { get; set; } = false;
        public bool IsFull { get; set; } = true;

        /// <summary>
        /// Конструктор по списку связности
        /// </summary>
        /// <param name="vertices"></param>
        public Graph(Dictionary<Vertex, List<Vertex>> listOfLinks)
        {
            ListOfLinks = listOfLinks;
            Vertices = listOfLinks.Keys.ToList();
            foreach (KeyValuePair<Vertex, List<Vertex>> pair in listOfLinks)
            {
                pair.Value.ForEach(value => Edges.Add(new Edge(pair.Key, value)));
            }
            
            IsOriented = Edges.All(
                edge => Edges.Except([edge]).Any(
                    another => edge.From == another.To
                    )
                );

            IsFull = Vertices.All(vertexCurrent =>
                    Vertices.Except([vertexCurrent]).All(
                        vertexFrom => 
                        Edges
                        .Where(x => x.From == vertexFrom)
                        .Any(y => y.To == vertexCurrent)
                    )
                );

            DestMatrix = FromListToMatrix(ListOfLinks);
        }

        /// <summary>
        /// Конструктор по матрице расстояний
        /// </summary>
        /// <param name="matrix"></param>
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

            IsOriented = IsOriented ? true : !CheckSymetria();

            ListOfLinks = FromMatrixToList(DestMatrix);
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

        /// <summary>
        /// Из DestMatrix получает список смежности
        /// </summary>
        /// <returns></returns>
        private Dictionary<Vertex,List<Vertex>> FromMatrixToList(List<List<int>> matrix)
        {
            return null;
        }

        /// <summary>
        /// Из ListOfLinks получает матрицу расстояний
        /// </summary>
        /// <returns></returns>
        private List<List<int>> FromListToMatrix(Dictionary<Vertex, List<Vertex>> list)
        {
            return null;
        }
    }
}
