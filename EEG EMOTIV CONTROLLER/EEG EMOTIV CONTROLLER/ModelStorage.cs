using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Eloquera.Client;
using System.IO;

namespace EEG_EMOTIV_CONTROLLER
{
    class ModelStorage
    {
        DB db;

        public ModelStorage()
        {
            db = new DB(Database.ConnectionString);
        }

        public void SaveModel(Model model)
        {
            if (!File.Exists(Database.fullpath))
            {
                db.CreateDatabase(Database.fullpath);
            }

            db.OpenDatabase(Database.fullpath);
            db.RefreshMode = ObjectRefreshMode.AlwaysReturnUpdatedValues;

            db.Store(model);

            db.Close();
        }

        public List<Model> LoadModels()
        {
            List<Model> result = new List<Model>();

            if (File.Exists(Database.fullpath))
            {
                db.OpenDatabase(Database.fullpath);

                db.RefreshMode = ObjectRefreshMode.AlwaysReturnUpdatedValues;

                if (db.IsTypeRegistered(typeof(Model).FullName))
                {
                    var query = from Model model in db select model;
                    result = query.ToList();
                }

                db.Close();
            }
            return result;
        }
    }
}
