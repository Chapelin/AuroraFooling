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

    

        public DataService()
        {
            this.dbConnection = new SQLiteConnection(Configuration.DatabasePath);
            this.dbConnection.CreateTable<MusicInfo>();
      }
     

     
        public bool Add(MusicInfo objet)
        {
            try
            {
              
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
     
            this.dbConnection.InsertAll(objets);
        }

        public void Clean() 
        {
          
            this.dbConnection.DeleteAll<MusicInfo>();
        }

        public IEnumerable<T> GetAll<T>() where T : new() 
        {
            return this.dbConnection.Table<T>().AsEnumerable();
        }

        public IEnumerable<T> Query<T>(Func<MusicInfo, bool> condition, Func<MusicInfo,T> select)
        {
            return this.dbConnection.Table<MusicInfo>().Where(condition).Select(select);

        }

        public IEnumerable<MusicInfo> Query(Func<MusicInfo, bool> condition)
        {
            return this.dbConnection.Table<MusicInfo>().Where(condition);

        }

      
    }
}
