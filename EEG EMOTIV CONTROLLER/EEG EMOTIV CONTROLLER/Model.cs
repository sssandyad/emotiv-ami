using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEG_EMOTIV_CONTROLLER
{
    class Model
    {

        string[] channelsEeg = { "AF3", "F7", "F3", "FC5", "T7", "P7", "O1", "O2", "P8", "T8", "FC6", "F4", "F8", "AF4" };
        string[] classesCommand = { "netral", "maju", "mundur", "kanan", "kiri" };

        public Dictionary<string, bool> channels;
        public Dictionary<string, bool> classes;

        public Dictionary<int, string> selectedChannelsIndex;

        public string name = "";
        public List<double[]> dataTraining;
        public List<double[]> dataTrainingFreq;
        public Dictionary<string, List<double[]>> spectral;
        public List<List<double>> features;
        public List<double> correctClass;
        public List<double> featureClass;

        public Model()
        {
            
            dataTraining = new List<double[]>();
            dataTrainingFreq = new List<double[]>();
            spectral = new Dictionary<string, List<double[]>>();
            features = new List<List<double>>();
            correctClass = new List<double>();
            featureClass = new List<double>();

            selectedChannelsIndex = new Dictionary<int, string>();

            channels = new Dictionary<string, bool>();
            for(int i=0;i<channelsEeg.Count();i++)
            {
                channels.Add(channelsEeg[i], false);
            }

            classes = new Dictionary<string, bool>();
            for(int i=0;i<classesCommand.Count();i++)
            {
                classes.Add(classesCommand[i], false);
            }
        }

        public void SetFeatureClass()
        {
            for(int i=0;i<correctClass.Count;i+=64)
            {
                featureClass.Add(correctClass[i]);
                //Console.WriteLine(correctClass[i]);
            }
        }

        public override string ToString()
        {
            string text = "";

            text += "name: " + name;
            text += "\n\rtotal record: " + dataTraining.Count.ToString();
            text += "\n\rjumlah kanal: " + GetTotalSelectedChannels().ToString();
            text += "\n\rkanal sensor yang digunakan: ";
            text += "\n\r   " + SelectedChannelsToString();
            text += "\n\rtotal kelas: " + GetTotalSelectedClasses().ToString();
            text += "\n\rkelas gerak: ";
            text += "\n\r   " + SelectedClassesToString();

            return text;
        }

        public int GetTotalData()
        {
            return dataTraining.Count;
        }

        public void SetChanelsIndex()
        {
            int index = 0;
            for (int i = 0; i < channelsEeg.Count(); i++)
            {
                if (channels[channelsEeg[i]])
                    selectedChannelsIndex.Add(index++, channelsEeg[i]);
            }
        }

        public int GetTotalSelectedChannels()
        {
            int totalSelectedChannels = 0;
            for (int i = 0; i < channelsEeg.Count(); i++)
            {
                if(channels[channelsEeg[i]])
                    totalSelectedChannels++;
            }

            return totalSelectedChannels;
        }

        public int GetTotalSelectedClasses()
        {
            int totalSelectedClasses = 0;
            for (int i = 0; i < classesCommand.Count(); i++)
            {
                if (classes[classesCommand[i]])
                    totalSelectedClasses++;
            }

            return totalSelectedClasses;
        }

        private string SelectedChannelsToString()
        {
            string selectedChannels = "";
            for (int i = 0; i < channelsEeg.Count(); i++)
            {
                if (channels[channelsEeg[i]])
                {
                    selectedChannels += (selectedChannels != "") ? ", " : "";
                    selectedChannels += channelsEeg[i];
                }
            }

            return selectedChannels;
        }

        private string SelectedClassesToString()
        {
            string selectedClasses = "";
            for (int i = 0; i < classesCommand.Count(); i++)
            {
                if (classes[classesCommand[i]])
                {
                    selectedClasses += (selectedClasses != "") ? ", " : "";
                    selectedClasses += classesCommand[i];
                }
            }

            return selectedClasses;
        }
    }
}
