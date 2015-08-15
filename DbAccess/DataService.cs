using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NDatabase;
using NDatabase.Api;

namespace DbAccess
{
    public class DataService
    {
        private IOdb _database;


        public void OpenDatabaseIfNecessary()
        {
            if (this._database == null || this._database.IsClosed())
            {
                this.OpenDataBase();
            }
        }

        public void OpenDataBase()
        {
            this._database = OdbFactory.Open(Configuration.ConnectionString);
        }

        public bool Add<T>(T objet) where T : class
        {
            try
            {
                this.OpenDatabaseIfNecessary();
                this._database.Store<T>(objet);

            }
            catch (Exception)
            {
                return false;

            }

            return true;
        }

        public void AddRange<T>(IEnumerable<T> objets) where T : class
        {
         
            Parallel.ForEach(objets, objet =>
            {
                this.Add(objet);
            });
            
           
        }

        public void Clean<T>() where T : class
        {
            this.OpenDatabaseIfNecessary();
            var listId = this._database.QueryAndExecute<T>();
            foreach (var oid in listId)
            {
                this._database.Delete(oid);
            }
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            this.OpenDatabaseIfNecessary();
            return this._database.QueryAndExecute<T>();
        }

        public IEnumerable<T> Query<T>(Func<T, bool> condition) where T : class
        {
            this.OpenDatabaseIfNecessary();
            return this._database.QueryAndExecute<T>().Where(condition);

        }

    }
}
