using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeuCondominio.Models;

namespace MeuCondominio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MeuCondominio.Models.Resident>? Resident { get; set; }
        public DbSet<MeuCondominio.Models.Apartment>? Apartment { get; set; }
        public DbSet<MeuCondominio.Models.Building>? Building { get; set; }
        public DbSet<MeuCondominio.Models.Occurrence>? Occurrence { get; set; }
    }
}