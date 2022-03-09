using System;
using Graf;

public class Program
{
    public static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.Generate();
        graph.WriteDestinations();
        graph.FindHurtigsteVej("D", "E");
    }
}