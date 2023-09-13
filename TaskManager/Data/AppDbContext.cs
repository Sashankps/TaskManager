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
                    new TaskListName { Id = 1, Name = "Work", CompletedTasks = 2, PendingTasks = 1 },
                    new TaskListName { Id = 2, Name = "Personal", CompletedTasks = 1, PendingTasks = 1 }
                );

                modelBuilder.Entity<UserTask>().HasData(
                    new UserTask { Id = 1, Name = "Finish project A", IsCompleted = true, TaskListNameId = 1 },
                    new UserTask { Id = 2, Name = "Meeting with client", IsCompleted = false, TaskListNameId = 1 },
                    new UserTask { Id = 3, Name = "Grocery shopping", IsCompleted = false, TaskListNameId = 2 },
                    new UserTask { Id = 4, Name = "Write report", IsCompleted = true, TaskListNameId = 1 },
                    new UserTask { Id = 5, Name = "Exercise", IsCompleted = true, TaskListNameId = 2 }
                );
        }



    }
}


