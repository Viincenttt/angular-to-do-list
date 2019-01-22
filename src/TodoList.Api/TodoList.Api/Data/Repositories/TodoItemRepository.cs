using System;
using System.Linq;
using TodoList.Api.Data.Models;

namespace TodoList.Api.Data.Repositories {
    public interface ITodoItemRepository : IRepository<TodoItem> {
        IQueryable<TodoItem> GetByApplicationUser(string applicationUserId);
    }

    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository {
        public TodoItemRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public IQueryable<TodoItem> GetByApplicationUser(string applicationUserId) {
            return this._dbContext.TodoItems.Where(x => x.ApplicationUserId == applicationUserId);
        }
    }
}