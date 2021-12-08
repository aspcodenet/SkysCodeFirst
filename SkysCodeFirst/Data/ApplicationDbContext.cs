using Microsoft.EntityFrameworkCore;

namespace SkysCodeFirst.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Invoice12345;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }


        public DbSet<Person> Person { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<County> County { get; set; }

    }
}