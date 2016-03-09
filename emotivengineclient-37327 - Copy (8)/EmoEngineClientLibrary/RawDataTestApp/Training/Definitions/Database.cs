using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Eloquera.Client;

namespace RawDataTestApp
{
    public class DbSettings
    {
        const string dbName = "EEG_Record_DB";

        public static string fullpath = Environment.CurrentDirectory + @"\..\..\..\..\data\" + dbName;

        public static string ConnectionString = "server=(local);options=none;";

        //public static DB db = new DB("server=(local);password=;options=inmemory,persist;");//in-memory save on exit
    }
}
