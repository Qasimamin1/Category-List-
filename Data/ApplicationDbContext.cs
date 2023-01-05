using BulkyBookNew.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookNew.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
