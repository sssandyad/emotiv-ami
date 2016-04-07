using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backpropagation
{
    class Neuron
    {
        public List<Edge> forwardPointer;
        public List<Edge> backwardPointer;
        public Point location;

        public Neuron(int x, int y)
        {
            forwardPointer = new List<Edge>();
            backwardPointer = new List<Edge>();

            location = new Point(x, y);
        }
    }
}
