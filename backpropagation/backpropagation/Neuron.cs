using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backpropagation
{
    class Neuron
    {
        public double value;
        public double sigmoid;
        public List<Pointer> forwardPointer;
        public List<Pointer> backwardPointer;

        public Neuron()
        {
            forwardPointer = new List<Pointer>();
            backwardPointer = new List<Pointer>();
        }
    }
}
