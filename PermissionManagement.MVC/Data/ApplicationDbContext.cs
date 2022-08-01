using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermissionManagement.MVC.Models;

namespace PermissionManagement.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProductViewModel> Product { get; set; }
        public DbSet<AdoptionCenter> AdoptionCenter { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<Adoption> Adoption { get; set; }
    }
}