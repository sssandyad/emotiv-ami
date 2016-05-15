using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BasicDSP;

namespace EEG_EMOTIV_CONTROLLER
{
    class BasicSignalProcessor
    {
        public List<double[]> Decomposes(double[] data)
        {
            int length = data.Length;
            double[] dataCombinedDeltaTheta = new double[length]; //delta = 1-3 Hz, theta = 4-7 Hz
            double[] dataAlpha = new double[length]; //alpha = 8-13 Hz
            double[] dataBeta = new double[length]; //beta = 14-29 Hz
            double[] dataGamma = new double[length]; //gamma = 30-50 Hz

            LTISystemChain chainCombinedDeltaTheta = Filter.ButterworthBandPass(0.01, 0.07, 4);
            LTISystemChain chainAlpha = Filter.ButterworthBandPass(0.08, 0.13, 4);
            LTISystemChain chainBeta = Filter.ButterworthBandPass(0.14, 0.29, 4);
            LTISystemChain chainGamma = Filter.ButterworthBandPass(0.30, 0.50, 4);

            for (int i = 0; i < length; i++)
            {
                //#region 1. ButterworthBandPass
                dataCombinedDeltaTheta[i] = chainCombinedDeltaTheta[data[i]];
                dataAlpha[i] = chainAlpha[data[i]];
                dataBeta[i] = chainBeta[data[i]];
                dataGamma[i] = chainGamma[data[i]];
                //#endregion
            }
            List<double[]> result = new List<double[]>();
            result.Add(dataCombinedDeltaTheta);
            result.Add(dataAlpha);
            result.Add(dataBeta);
            result.Add(dataGamma);

            return result;
        }
    }
}
