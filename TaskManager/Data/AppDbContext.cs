using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<TaskListName> TaskListNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskListName>().HasData(
                new TaskListName { Id = 1, Name = "Work" },
                new TaskListName { Id = 2, Name = "Personal" }
            );

            modelBuilder.Entity<UserTask>().HasData(
                new UserTask { Id = 1, Name = "Finish project A", IsCompleted = false, TaskListNameId = 1 },
                new UserTask { Id = 2, Name = "Meeting with client", IsCompleted = false, TaskListNameId = 1 },
                new UserTask { Id = 3, Name = "Grocery shopping", IsCompleted = false, TaskListNameId = 2 }
            );
        }
    }
}
