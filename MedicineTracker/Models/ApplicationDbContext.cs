using Microsoft.EntityFrameworkCore;


namespace MedicineTracker.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public ApplicationDbContext(DbContextOptions options): base(options)
        {
        }

    }
}
