using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backpropagation
{
    class Neuron
    {
        public double potensialAktivasi;
        public double outputNeuron;
        public double derivativeBinarySigmoid;
        public double threshold;
        public double delta;
        public List<Edge> forwardPointer;
        public List<Edge> backwardPointer;

        public Neuron()
        {
            forwardPointer = new List<Edge>();
            backwardPointer = new List<Edge>();

            //inisialisasi threshold dengan angka random antara 0 - 0.5
            Random rand = new Random();
            threshold = rand.Next(0, 5) * 0.1;
        }
    }
}
