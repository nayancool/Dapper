namespace Dapper.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetById(int id);

        Task<int> Add(T entity);

        Task<int> Update(T entity);

        Task<int> DeleteById(int id);
    }
}