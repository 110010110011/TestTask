using Microsoft.EntityFrameworkCore;

namespace TestTaskYanenko.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }


        public DbSet<ActivityType> ActivityType { get; set; }
        
        public DbSet<Activity> Activity { get; set; }
        
        public DbSet<Employee> Employee { get; set; }
        
        public DbSet<Project> Project { get; set; }
        
        public DbSet<Role> Role { get; set; }
    }
}
