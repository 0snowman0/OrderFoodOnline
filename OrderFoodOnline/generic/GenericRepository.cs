using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.Model.ConnectionToBank;

namespace OrderFoodOnline.generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context_En _context;
        private DbSet<T> table;
        public GenericRepository(Context_En context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task Add(List<T> entities)
        {
            await _context.BulkInsertAsync(entities);
        }

        public async Task Add(T entity)
        {
            await _context.BulkInsertAsync(new List<T> { entity });
        }

        public async Task AddList(List<T> entities)
        {
            // بررسی اینکه لیست عناصر خالی نباشد
            if (entities.Count == 0)
            {
                return;
            }

            // افزودن عناصر به پایگاه داده به صورت Bulk Insert
            var query = _context.Set<T>().BulkInsertAsync(entities);
        }

        public async Task Delete(List<int> ids)
        {
            var entities = new List<T>();

            foreach (var id in ids)
            {
                var entity = await Get(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with ID {id} not found.");
                }

                entities.Add(entity);
            }

            await _context.BulkDeleteAsync(entities);
        }

        public async Task<T?> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await table.ToListAsync();
        }

        public async Task<T?> Get_List(List<int> Ids)
        {
            throw new ArgumentNullException(nameof(Ids));
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            await _context.BulkUpdateAsync(new List<T> { entity });
        }
    }
}
