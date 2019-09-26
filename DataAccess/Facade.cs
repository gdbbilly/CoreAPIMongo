using System;
using App.Service.Web.Business;

namespace App.Service.Web.DataAccess
{
    public sealed class Facade
    {
        private static readonly Facade instance = new Facade();  
        private static string _connectionString;
        private static string _databaseConnection;
        private Facade()
        {
        }
        static Facade()  
        {  
             
        }  

        public BaseBusiness<U> Factory<U>()
        {
            return new BaseBusiness<U>();
        }

        public T Factory<T, U>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public static void Initialize(string ConnectionString, string DatabaseConnection)
        {
            _connectionString = ConnectionString;
            _databaseConnection = DatabaseConnection;
            
            DbClient.Initialize(ConnectionString, DatabaseConnection);
        }

        public static Facade Instance
        {
            get
            {
                if (instance == null)
                {
                    if (string.IsNullOrEmpty(_connectionString) || string.IsNullOrEmpty(_databaseConnection))
                        throw new Exception("Error");
                }

                return instance;
            }
        }
    }
}