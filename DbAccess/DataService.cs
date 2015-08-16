using System;
using System.Collections.Generic;
using System.Data;
using SQLite;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DbAccess
{
    public class DataService
    {
        private SQLiteConnection dbConnection;

        //static DataService()
        //{
        //    if (!System.IO.File.Exists(Configuration.DatabasePath))
        //    {
        //        SQLiteConnection.CreateFile(Configuration.DatabasePath);
                
        //    }
        //}

        public DataService()
        {
            this.dbConnection = new SQLiteConnection(Configuration.DatabasePath);
            this.dbConnection.CreateTable<MusicInfo>();
;        }
        public void OpenDatabaseIfNecessary()
        {
           
            //if (this.dbConnection != ConnectionState.Open)
            //{
            //    this.OpenDataBase();
            //}
        }

        public void OpenDataBase()
        {
            //this.dbConnection.Open();
        }

        public bool Add(MusicInfo objet)
        {
            try
            {
                this.OpenDatabaseIfNecessary();
                this.dbConnection.Insert(objet);

            }
            catch (Exception e)
            {
                return false;

            }

            return true;
        }

        public void AddRange(IEnumerable<MusicInfo> objets)
        {
            this.OpenDatabaseIfNecessary();
            this.dbConnection.InsertAll(objets);
        }

        public void Clean() 
        {
            this.OpenDatabaseIfNecessary();
            this.dbConnection.DeleteAll<MusicInfo>();
        }

        public IEnumerable<MusicInfo> GetAll()
        {
            this.OpenDatabaseIfNecessary();
            return this.dbConnection.Table<MusicInfo>().AsEnumerable();
        }

        public IEnumerable<MusicInfo> Query(Func<MusicInfo, bool> condition)
        {
            this.OpenDatabaseIfNecessary();
            return this.dbConnection.Table<MusicInfo>().Where(condition);

        }

    }
}
