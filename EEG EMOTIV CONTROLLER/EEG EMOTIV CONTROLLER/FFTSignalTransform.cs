using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MathNet.Numerics.Transformations;

namespace EEG_EMOTIV_CONTROLLER
{
    class FFTSignalTransform
    {
        const int power = 5;
        static int windowsize = (int)Math.Pow(2, power);
        int windowLength = 0;
        int totalChannels;
        List<double[]> windowChannels;
        double[] result;

        //window for each channel

        public void Init(int channelCount)
        {
            windowLength = 0;
            totalChannels = channelCount;
            windowChannels = new List<double[]>();
            for(int i=0;i<channelCount;i++)
            {
                windowChannels.Add(new double[windowsize]);
            }
        }

        /// <summary>
        /// Currently only first channel
        /// </summary>
        /// <param name="data"></param>
        public double[] DoWork(double[] data)
        {
            //1. wait until window buffer is full
            if (windowLength < windowsize)
            {
                for (int i = 0; i < totalChannels; i++)
                {
                    windowChannels[i][windowLength] = data[i];
                }
                windowLength++;

                return data;
            }
            else //window buffer full 
            {
                result = new double[totalChannels];

                //2. perform fft
                for (int i = 0; i < totalChannels; i++)
                {
                    double[] freqReal, freqImag;
                    RealFourierTransformation rft = new RealFourierTransformation(); // default convention
                    rft.TransformForward(windowChannels[i], out freqReal, out freqImag);

                    //3. move left 
                    for (int j = windowChannels[i].Length - 2; j >= 0; j--)
                        windowChannels[i][j + 1] = windowChannels[i][j];

                    //4. set new value to be used next time
                    windowChannels[i][0] = data[i];

                    //5. Fill first value for return
                    result[i] = freqReal[0];
                }

                return result;
            }
        }
    }
}
