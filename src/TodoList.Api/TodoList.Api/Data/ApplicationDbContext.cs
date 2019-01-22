using Microsoft.EntityFrameworkCore;


namespace TodoList.Api.Data {
    public class ApplicationDbContext : DbContext {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}