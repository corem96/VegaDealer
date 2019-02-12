using Microsoft.EntityFrameworkCore;
using Vega.Domain.Models;

namespace Vega.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
        
        public DbSet<Make> Makes { get; set; }
    }
}