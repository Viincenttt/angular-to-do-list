using Microsoft.EntityFrameworkCore;
using Moq;
using TodoList.Api.Data;
using TodoList.Api.Data.Models;
using TodoList.Api.Services;
using Xunit;

namespace TodoList.Tests.Data {
    public class ApplicationDbContextTests {
        [Fact]
        public async void OnModelCreating_ShouldFilterTodoItemsOnApplicationUser_WhenPerformingAnyQuery() {
            // Given: A in memory database context
            var userIdProvider = new Mock<IUserIdProvider>();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TodoList")
                .Options;

            using (var context = new ApplicationDbContext(options, userIdProvider.Object)) {
                // When: Creating two users, each having a single todo item
                ApplicationUser currentUser = new ApplicationUser();
                ApplicationUser otherUser = new ApplicationUser();
                context.ApplicationUsers.Add(currentUser);
                context.ApplicationUsers.Add(otherUser);
                context.SaveChanges();

                userIdProvider.Setup(x => x.GetUserId()).Returns(currentUser.Id);
                
                context.TodoItems.Add(new TodoItem() {
                    ApplicationUser = currentUser,
                    Title = "Create more integration tests",
                    Description = "But always have more unit tests",
                    SortOrder = "0"            
                });

                context.TodoItems.Add(new TodoItem() {
                    ApplicationUser = otherUser,
                    Title = "Bake cookies",
                    Description = "",
                    SortOrder = "1"
                });

                context.SaveChanges();

                // Then: The TodoItems DbSet should only return the item that belong to the current user
                Assert.Equal(1, await context.TodoItems.CountAsync());
            }
        }
    }
}
