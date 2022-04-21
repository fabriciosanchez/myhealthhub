namespace myhealthhub.api.Interfaces
{
    public interface IDatabaseManager
    {
        public Task Create<T>(T entity) where T : class;
    }
}