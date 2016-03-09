using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawDataTestApp
{
    public interface IDigitalSignalProcessor
    {
        void DoWork(ref double[] data);
    }
}
