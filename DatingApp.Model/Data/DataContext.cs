using DatingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Model.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Represents data tables that will be created in the database.
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
