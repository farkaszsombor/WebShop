using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Cart> Carts{ get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Geo> Geos { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
