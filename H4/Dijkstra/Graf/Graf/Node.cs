using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    public class Node
    {
        public List<Vertex> vertexes = new List<Vertex>();
        public string name;
        public Node(string name)
        {
            this.name = name;
        }

        public List<Node> FindFastestWay(Node from, Node to, List<Node> availableNodes, List<Vertex> availableVertexes, int currentWeight, List<Node> FastestPath, Vertex fromVertex)
        {
            //availableNodes is a list of priority nodes
            //weights is a list of priority node weights
            
            currentWeight = fromVertex.weight;
            availableNodes.Remove(this);
            availableVertexes.Remove(fromVertex);
            if (availableNodes.Count == 0)
            {
                Console.WriteLine("Nowhere to go");
            }
            if (this.name == to.name)
            {
                Console.WriteLine("Yay you found " + name);
                FastestPath.Add(this);
                FastestPath.Add(fromVertex.start);
                return FastestPath;
            }
            List<Node> vertexDest = new List<Node>();
            for (int i = 0; i < vertexes.Count; i++)
            {
                vertexDest.Add(vertexes[i].destination);
                for (int j = 0; j < availableNodes.Count; j++)
                {
                    if (availableNodes[j] == vertexes[i].destination)
                    {
                        if (availableVertexes[j].weight > vertexes[i].weight + currentWeight)
                        {
                            Console.WriteLine(availableVertexes[j].weight + " this is their original weight " + vertexes[i].start.name + vertexes[i].destination.name);
                            availableVertexes[j].weight = vertexes[i].weight + currentWeight;
                            availableVertexes[j].start = vertexes[i].start;
                            Console.WriteLine("Changed weight to " + availableVertexes[j].weight + " " + vertexes[i].start.name + vertexes[i].destination.name);
                        }
                    }
                }
            }
            for (int i = 0; i < vertexDest.Count; i++)
            {
                if (!availableNodes.Contains(vertexDest[i]))
                {
                    Console.WriteLine(vertexes[i].weight + " this is their non-original weight " + vertexes[i].start.name + vertexes[i].destination.name);
                    vertexes[i].weight += currentWeight;
                    availableNodes.Add(vertexDest[i]);
                    availableVertexes.Add(vertexes[i]);
                }
            }
            foreach (var item in availableVertexes)
            {
                Console.WriteLine(item.destination.name + " " + item.weight);
            }
            int lowestWeight = 100;
            int number = 0;
            for (int i = 0; i < availableVertexes.Count; i++)
            {
                if (lowestWeight > availableVertexes[i].weight)
                {
                    number = i;
                    lowestWeight = availableVertexes[i].weight;
                }
            }
            
            currentWeight = availableVertexes[number].weight;
            Console.WriteLine(availableVertexes[number].start.name + " going to " + availableVertexes[number].destination.name);
            Console.WriteLine(currentWeight);
            if(availableNodes[number].FindFastestWay(this, to, availableNodes, availableVertexes, currentWeight, FastestPath, availableVertexes[number]).Contains(this))
            {
                FastestPath.Add(fromVertex.start);
            }
            
            return FastestPath;
        }
        public List<Node> FindFastestWay(Node from, Node to, List<Node> availableNodes, List<Vertex> availableVertexes, int currentWeight, List<Node> FastestPath)
        {
            //availableNodes is a list of priority nodes
            //weights is a list of priority node weights
            availableNodes.Remove(this);
            if (availableNodes.Count == 0)
            {
                Console.WriteLine("Nowhere to go");
            }
            if (this.name == to.name)
            {
                Console.WriteLine("Yay you found " + name);
                FastestPath.Add(this);
                return FastestPath;
            }
            List<Node> vertexDest = new List<Node>();
            for (int i = 0; i < vertexes.Count; i++)
            {
                vertexDest.Add(vertexes[i].destination);
                for (int j = 0; j < availableNodes.Count; j++)
                {
                    if (availableNodes[j] == vertexes[i].destination)
                    {
                        if (availableVertexes[j].weight > vertexes[i].weight)
                        {
                            availableVertexes[j].weight = vertexes[i].weight;
                        }
                    }
                }
            }
            for (int i = 0; i < vertexDest.Count; i++)
            {
                if (!availableNodes.Contains(vertexDest[i]))
                {
                    vertexes[i].weight += currentWeight;
                    availableNodes.Add(vertexDest[i]);
                    availableVertexes.Add(vertexes[i]);
                }
            }
            int lowestWeight = 100;
            int number = 0;
            for (int i = 0; i < availableVertexes.Count; i++)
            {
                if (lowestWeight > availableVertexes[i].weight)
                {
                    number = i;
                    lowestWeight = availableVertexes[i].weight;
                }
            }
            currentWeight = availableVertexes[number].weight;
            Console.WriteLine(name + " going to " + availableNodes[number].name);
            Console.WriteLine(currentWeight);

            availableNodes[number].FindFastestWay(this, to, availableNodes, availableVertexes, currentWeight, FastestPath, availableVertexes[number]);
            
            return FastestPath;
        }
    }
}