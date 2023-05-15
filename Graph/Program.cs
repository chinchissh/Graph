using System;

namespace Graph //Взвещенный граф для поиска кратчайшего пути алгоритмом Дейкстры
{
    class Program
    {
        static void Main(string[] args)
        {
            WeightedGraph graph = new WeightedGraph(5); //Эта строка создает объект класса WeightedGraph и присваивает его переменной graph.

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 2, 1);
            graph.AddEdge(2, 1, 2);
            graph.AddEdge(2, 3, 5);
            graph.AddEdge(1, 3, 1);
            graph.AddEdge(3, 4, 3); //Эти строки добавляют ребра с весами в объект графа.

            graph.Dijkstra(0); //Эта строка вызывает метод Dijkstra для поиска кратчайшего пути в графе, начиная с вершины 0.

            Console.ReadLine(); //Эта строка ожидает ввода пользователем перед завершением работы программы.
        }
    }
} 