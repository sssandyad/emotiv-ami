using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backpropagation
{
    class Edge
    {
        public double weight;
        public Neuron front;
        public Neuron back;

        public Edge(double w)
        {
            weight = w;
        }
    }
}
