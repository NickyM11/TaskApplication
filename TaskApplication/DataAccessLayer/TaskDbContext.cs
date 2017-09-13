using System.Data.Entity;
using TaskApplication.Models;

namespace TaskApplication.DataAccessLayer
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
    }
}