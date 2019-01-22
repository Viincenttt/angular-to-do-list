using TodoList.Api.Data.Models;

namespace TodoList.Api.Data.Repositories {
    public interface ITodoItemRepository : IRepository<TodoItem> {
    }

    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository {
        public TodoItemRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}