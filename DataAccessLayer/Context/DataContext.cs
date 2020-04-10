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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartProduct>()
            .HasKey(t => new { t.CartId, t.ProductId });

            modelBuilder.Entity<CartProduct>()
            .HasOne(ho => ho.Cart)
            .WithMany(w => w.CartProducts)
            .HasForeignKey(hf => hf.CartId);

            modelBuilder.Entity<CartProduct>()
                .HasOne(ho => ho.Product)
                .WithMany(w => w.CartProducts)
                .HasForeignKey(hf => hf.ProductId);


            modelBuilder.Entity<KeywordProduct>()
                .HasKey(t => new { t.KeywordId, t.ProductId });

            modelBuilder.Entity<KeywordProduct>()
            .HasOne(ho => ho.Keyword)
            .WithMany(w => w.KeywordProducts)
            .HasForeignKey(hf => hf.KeywordId);

            modelBuilder.Entity<KeywordProduct>()
                .HasOne(ho => ho.Product)
                .WithMany(w => w.KeywordProducts)
                .HasForeignKey(hf => hf.ProductId);



            modelBuilder.Entity<Image>()
            .HasOne(ho => ho.Product)
            .WithMany(w => w.Images)
            .HasForeignKey(hf => hf.ProductId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
