using DatingApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.Model.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Value> Values { get; set; }
    }
}
