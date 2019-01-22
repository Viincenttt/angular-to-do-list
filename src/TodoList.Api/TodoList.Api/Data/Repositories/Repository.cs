using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Api.Data.Repositories {
    public interface IRepository<T> where T : class {
        void Add(T entity);
        void Delete(T entity);
        Task<bool> SaveChanges();
        IQueryable<T> GetAll();
        T GetById(int id);
    }

    public abstract class Repository<T> : IRepository<T> where T : class {
        protected readonly ApplicationDbContext _dbContext;

        protected Repository(ApplicationDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public IQueryable<T> GetAll() {
            return this._dbContext.Set<T>();
        }

        public T GetById(int id) {
            return this._dbContext.Set<T>().Find(id);
        }

        public void Add(T entity) {
            this._dbContext.Add(entity);
        }

        public void Delete(T entity) {
            this._dbContext.Remove(entity);
        }

        public async Task<bool> SaveChanges() {
            return await this._dbContext.SaveChangesAsync() > 0;
        }
    }
}