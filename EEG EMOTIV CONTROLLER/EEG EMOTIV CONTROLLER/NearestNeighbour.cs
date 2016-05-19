using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EEG_EMOTIV_CONTROLLER
{
    class NearestNeighbour
    {
        Model m;
        double[] distance;
        int[] indexDistance;
        int totalData;
        int totalFeature;
        
        public NearestNeighbour(Model model)
        {
            m = model;
            totalData = m.features.Count;
            totalFeature = m.features[0].Count;
            distance = new double[totalData];
            indexDistance = new int[totalData];
            for(int i=0; i<totalData;i++)
            {
                indexDistance[i] = i;
            }
        }

        public int Classify(List<double> test, int k)
        {
            CalculateDistance(test);
            SortDistanceIndex();

            int[] result = new int[5];

            for(int i=0; i<k; i++)
            {
                result[m.featureClass[indexDistance[i]]]++;
            }

            int max = 0;
            int finalClass = 0;
            for (int i = 0; i < 5; i++)
            {
                if(max < result[i])
                {
                    max = result[i];
                    finalClass = i;
                }
            }

            //Console.WriteLine(finalClass);
            return finalClass;
        }

        private void CalculateDistance(List<double> test)
        {
            for (int i = 0; i < totalData; i++)
            {
                distance[i] = 0;
                for (int j = 0; j < totalFeature; j++)
                {
                    distance[i] += Math.Pow((m.features[i][j] - test[j]), 2);
                }
                distance[i] = Math.Sqrt(distance[i]);
            }
        }

        private void SortDistanceIndex()
        {
            for (int i = 0; i < totalData - 1; i++)
            {
                for (int j = i + 1; j < totalData; j++)
                {
                    if (distance[indexDistance[j]] < distance[indexDistance[i]])
                    {
                        int temp = indexDistance[j];
                        indexDistance[j] = indexDistance[i];
                        indexDistance[i] = temp;
                    }
                }
            }
        }
    }
}
