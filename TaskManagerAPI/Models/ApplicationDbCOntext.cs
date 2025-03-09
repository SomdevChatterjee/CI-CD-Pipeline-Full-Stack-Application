using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Work" },
                new Category { CategoryId = 2, CategoryName = "Personal" },
                new Category { CategoryId = 3, CategoryName = "Urgent" }
            );

            // Seeding Users (Passwords should be hashed in production)
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "John Doe", Email = "john@example.com", Password = "hashedpassword1" },
                new User { UserId = 2, FullName = "Jane Smith", Email = "jane@example.com", Password = "hashedpassword2" }
            );

            // Seeding Tasks
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { TaskId = 1, Title = "Complete project report", Description = "Finalize and submit the report", Status = TaskStatus.InProgress, Priority = TaskPriority.High, DueDate = DateTime.UtcNow.AddDays(2), UserId = 1, CategoryId = 1 },
                new TaskItem { TaskId = 2, Title = "Grocery Shopping", Description = "Buy vegetables and fruits", Status = TaskStatus.ToDo, Priority = TaskPriority.Medium, DueDate = DateTime.UtcNow.AddDays(1), UserId = 2, CategoryId = 2 },
                new TaskItem { TaskId = 3, Title = "Team Meeting", Description = "Discuss project progress", Status = TaskStatus.Done, Priority = TaskPriority.High, DueDate = DateTime.UtcNow.AddDays(-1), UserId = 1, CategoryId = 1 }
            );
        }
    }
}