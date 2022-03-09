using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{ 
    public class Graph
    {
        public List<Node> nodes = new List<Node>();
        public void FindHurtigsteVej(string from, string to)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].name == from)
                {
                    foreach (var item in nodes)
                    {
                        if (item.name == to)
                        {
                            List<Node> nodeList = new List<Node>();
                            List<Vertex> weights = new List<Vertex>();
                            List<Node> fastestPath = new List<Node>();
                            foreach (var item1 in nodes[i].vertexes)
                            {
                                nodeList.Add(item1.destination);
                                weights.Add(item1);
                                Console.WriteLine(item1.destination.name);
                            }
                            List<Node> fastestWay = nodes[i].FindFastestWay(nodes[i], item, nodeList, weights, 0, fastestPath);
                            foreach (var item2 in fastestWay)
                            {
                                Console.WriteLine(item2.name);
                            }
                        }
                    }
                }
            }
        }

        public void WriteDestinations()
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < nodes[i].vertexes.Count; j++)
                {
                    Console.WriteLine(nodes[i].name + " goes to " + nodes[i].vertexes[j].destination.name);
                }
            }
        }

        public void Generate()
        {
            Node A = new Node("A");
            nodes.Add(A);
            Node B = new Node("B");
            nodes.Add(B);
            Node C = new Node("C");
            nodes.Add(C);
            Node D = new Node("D");
            nodes.Add(D);
            Node E = new Node("E");
            nodes.Add(E);
            Node F = new Node("F");
            nodes.Add(F);
            Node G = new Node("G");
            nodes.Add(G);
            Node H = new Node("H");
            nodes.Add(H);
            Node I = new Node("I");
            nodes.Add(I);
            Vertex AD = new Vertex(5, D, A);
            A.vertexes.Add(AD);
            Vertex AB = new Vertex(2, B, A);
            A.vertexes.Add(AB);
            Vertex AE = new Vertex(4, E, A);
            A.vertexes.Add(AE);
            Vertex BE = new Vertex(1, E, B);
            B.vertexes.Add(BE);
            Vertex CB = new Vertex(3, B, C);
            C.vertexes.Add(CB);
            Vertex EF = new Vertex(3, F, E);
            E.vertexes.Add(EF);
            Vertex EH = new Vertex(6, H, E);
            E.vertexes.Add(EH);
            Vertex FC = new Vertex(4, C, F);
            F.vertexes.Add(FC);
            Vertex FH = new Vertex(3, H, F);
            F.vertexes.Add(FH);
            Vertex DG = new Vertex(2, G, D);
            D.vertexes.Add(DG);
            Vertex GH = new Vertex(1, H, G);
            G.vertexes.Add(GH);
            Vertex HI = new Vertex(1, I, H);
            H.vertexes.Add(HI);
            Vertex IF = new Vertex(1, F, I);
            I.vertexes.Add(IF);
        }
    }
}
