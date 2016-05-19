using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEG_EMOTIV_CONTROLLER
{
    class Database
    {
        const string dbName = "DATABASE_EEG";

        public static string fullpath = Environment.CurrentDirectory + @"\..\..\..\" + dbName;

        public static string ConnectionString = "server=(local);options=none;";

        //public static DB db = new DB("server=(local);password=;options=inmemory,persist;");//in-memory save on exit
    }
}
