using Aionys.DAL.Domain;
using Microsoft.EntityFrameworkCore;


namespace Aionys.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
