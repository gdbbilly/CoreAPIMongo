using MongoDB.Driver;

namespace App.Service.Web.DataAccess
{
   public class DbClient
    {
        private static IMongoDatabase _database;
        private static MongoClient _client;
        private static string _connectionString { get; set; }
        private static string _databaseName { get; set; }

        internal static void Initialize(string pConnectionString, string pDatabaseName)
        {
            _connectionString = pConnectionString;
            _databaseName = pDatabaseName;
        }

        private static MongoClient Client
        {
            get
            {
                if (_client == null || string.IsNullOrEmpty(_connectionString) || string.IsNullOrEmpty(_databaseName))
                {
                    _client = new MongoClient(_connectionString);
                }

                return _client;
            }
        }

        public static IMongoDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = Client.GetDatabase(_databaseName);
                }

                return _database;
            }
        }
    }
}
