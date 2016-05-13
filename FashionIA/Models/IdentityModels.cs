using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FashionIA.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<User> user { get; set; }
        public DbSet<Admin> admin { get; set; }
        public DbSet<Editor> editor { get; set; }
        public DbSet<Article> article { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Favourate> favourate { get; set; }
        public DbSet<Feedback> feedback { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<TempArticle> tempArticle { get; set; }
        public DbSet<Vote> vote { get; set; }
        public DbSet<Advertise> advertise { get; set; }
    }
}