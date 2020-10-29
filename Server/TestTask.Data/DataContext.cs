using Microsoft.EntityFrameworkCore;

namespace TestTask.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<NoteEntity> NoteEntities { get; set; }
    }
}
