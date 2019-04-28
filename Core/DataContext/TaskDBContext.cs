using Microsoft.EntityFrameworkCore;

namespace Core.DataContext
{
    public class TaskDBContext : DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.TaskListModel> TaskList { get; set; }
        public DbSet<Models.LogModel> LogModel { get; set; }

    }
}
