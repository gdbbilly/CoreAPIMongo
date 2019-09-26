namespace App.Service.Web.DataAccess
{
    public class FactoryDatabase<T>
    {
        public Repository<T> Instance { get; private set; }
        public FactoryDatabase()
        {
             Instance = new Repository<T>($"{typeof(T).Name}");
        }
    }
}
