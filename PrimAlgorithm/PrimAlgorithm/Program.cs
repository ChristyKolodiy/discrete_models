using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimAlgorithm
{
    class Program
    {
        class MST
        {
            static int V = 8;

            static int minKey(int[] key, bool[] mstSet)
            {

                int min = int.MaxValue, min_index = -1;

                for (int v = 0; v < V; v++)
                    if (mstSet[v] == false && key[v] < min)
                    {
                        min = key[v];
                        min_index = v;
                    }

                return min_index;
            }

            static void printMST(int[] parent, int[,] graph)
            {
                Console.WriteLine("Edge \tWeight");
                for (int i = 1; i < V; i++)
                    Console.WriteLine(parent[i] + " - " + i + "\t" + graph[i, parent[i]]);
            }

            static void primMST(int[,] graph)
            {
                
                int[] parent = new int[V];
                int[] key = new int[V];
                bool[] mstSet = new bool[V];
                for (int i = 0; i < V; i++)
                {
                    key[i] = int.MaxValue;
                    mstSet[i] = false;
                }
                key[0] = 0;
                parent[0] = -1;

                for (int count = 0; count < V - 1; count++)
                {
                    int u = minKey(key, mstSet);

                    mstSet[u] = true;

                    for (int v = 0; v < V; v++)
                        if (graph[u, v] != 0 && mstSet[v] == false
                            && graph[u, v] < key[v])
                        {
                            parent[v] = u;
                            key[v] = graph[u, v];
                        }
                }

                printMST(parent, graph);
            }

            public static void Main()
            {

                String input = File.ReadAllText("C:\\4 курс\\2 семестр\\discrete models\\PrimAlgorithm\\PrimAlgorithm.txt");

                int i = 0, j = 0;
                    int[,] graph = new int[8, 8];
                    foreach (var row in input.Split('\n'))
                    {
                        j = 0;
                        foreach (var col in row.Trim().Split(' '))
                        {
                            graph[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                        i++;
                    }
                primMST(graph);
                Console.ReadKey();
            }
        }
    }
}