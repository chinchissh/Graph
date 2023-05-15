using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class WeightedGraph
    {
        private int[,] adjacencyMatrix; //матрица смежности
        private int numVertices; //количество вершин в графе

        public WeightedGraph(int numVertices) //Этот конструктор инициализирует объект класса WeightedGraph
        {
            this.numVertices = numVertices; // Задает количество вершин в графе
            adjacencyMatrix = new int[numVertices, numVertices]; // Создает новую матрицу смежности размером [numVertices, numVertices]
        }

        public void AddEdge(int source, int destination, int weight) //Этот метод добавляет ребро между двумя вершинами графа
        {
            adjacencyMatrix[source, destination] = weight; // Устанавливает вес ребра между source и destination
            adjacencyMatrix[destination, source] = weight; //// Устанавливает вес обратного ребра между destination и source
        }

        public void Dijkstra(int sourceVertex) //Этот метод реализует алгоритм Дейкстры для поиска кратчайшего пути в графе.
        {
            int[] shortestDistances = new int[numVertices]; //Массив кратчайших расстояний от источника до каждой вершины
            bool[] visitedVertices = new bool[numVertices]; //Массив, отслеживающий посещенные вершины

            for (int i = 0; i < numVertices; i++) //Этот цикл инициализирует массив shortestDistances 
            {
                shortestDistances[i] = int.MaxValue; // Устанавливает начальное значение кратчайшего расстояния для вершины i в максимально возможное значение
                visitedVertices[i] = false; //// Устанавливает начальное значение посещенности для вершины i в значение false
            }

            shortestDistances[sourceVertex] = 0; //Устанавливается начальное расстояние от источника до самого себя равным 0.

            for (int i = 0; i < numVertices - 1; i++) //Этот цикл выполняется numVertices - 1 раз для поиска кратчайшего пути до каждой вершины.
            {
                int nearestVertex = -1; // Инициализирует переменную nearestVertex значением -1
                int shortestDistance = int.MaxValue; //// Инициализирует переменную shortestDistance значением int.MaxValue


                for (int vertex = 0; vertex < numVertices; vertex++) //Этот метод выполняет поиск ближайшей непосещенной вершины с наименьшим кратчайшим расстоянием от источника
                {
                    if (!visitedVertices[vertex] && shortestDistances[vertex] < shortestDistance) // Проверяет, что вершина vertex не была посещена и имеет кратчайшее расстояние меньше shortestDistance
                    {
                        nearestVertex = vertex;
                        shortestDistance = shortestDistances[vertex]; // Обновляет nearestVertex и shortestDistance
                    }
                }

                visitedVertices[nearestVertex] = true; //Отмечается, что вершина nearestVertex была посещена.


                for (int vertex = 0; vertex < numVertices; vertex++)
                {
                    int edgeDistance = adjacencyMatrix[nearestVertex, vertex]; // Получает вес ребра между nearestVertex и vertex

                    if (edgeDistance > 0 && ((shortestDistance + edgeDistance) < shortestDistances[vertex])) // Проверяет, что ребро существует (имеет положительный вес) и новый путь (shortestDistance + edgeDistance) является более коротким
                    {
                        shortestDistances[vertex] = shortestDistance + edgeDistance; // Обновляет кратчайшее расстояние до вершины vertex
                    }
                }
            }

            Console.WriteLine("Вершина\t\tКратчайшее расстояние");

            for (int i = 0; i < numVertices; i++)
            {
                Console.WriteLine("{0}\t\t{1}", i, shortestDistances[i]); // Выводит номер вершины и ее кратчайшее расстояние от источника
            }
        }
    }
}

/*Кратчайший путь от вершины 0 до вершины 0: 0
Кратчайший путь от вершины 0 до вершины 1: 3 (0 -> 2 -> 1)
Кратчайший путь от вершины 0 до вершины 2: 1 (0 -> 2)
Кратчайший путь от вершины 0 до вершины 3: 4 (0 -> 1 -> 3)
Кратчайший путь от вершины 0 до вершины 4: 7 (0 -> 1 -> 3 -> 4)*/