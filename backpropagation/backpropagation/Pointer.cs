using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backpropagation
{
    class Pointer
    {
        public double weight;
        public Neuron front;
        public Neuron back;

        public Pointer(double w)
        {
            weight = w;
        }
    }
}
