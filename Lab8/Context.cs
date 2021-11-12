using Microsoft.EntityFrameworkCore;

namespace Lab8
{
    public class Context: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=Lab8;User=sa;Password=P@55w0rd;");
        }
    }
}