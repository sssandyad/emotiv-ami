using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawDataTestApp
{
    public delegate void ChangedFeaturesEventHandler(double[] featureVectors);

    public interface IFeatureGenerator
    {
        void Update();

        event ChangedFeaturesEventHandler Values;
    }
}
