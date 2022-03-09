using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf
{
    public class Vertex
    {
        public int weight;
        public Node destination;
        public Node start;
        public Vertex(int weight, Node destination, Node start)
        {
            this.weight = weight;
            this.destination = destination;
            this.start = start;
        }
    }
}
