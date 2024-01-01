namespace OrderFoodOnline.generic
{
    public interface IGenericRepository<T>
    {
        Task<T?> Get_List(List<int> Ids);
        Task<T?> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task AddList(List<T> entities);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(List<int> ids);
        void Save();
        Task SaveAsync();
    }
}
