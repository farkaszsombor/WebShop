using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessLayer.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Cart> Carts{ get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Geo> Geos { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CartProductNtoN
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
            #endregion


            #region KeywordProductNtoN
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
            #endregion


            #region ProductImagesOneToN
            modelBuilder.Entity<Image>()
               .HasOne(ho => ho.Product)
               .WithMany(w => w.Images)
               .HasForeignKey(hf => hf.ProductId);
            #endregion

            #region DataSeed


            Geo geo1 = new Geo { County = "Bihor", Locality = "Oradea" };
            Geo geo2 = new Geo { County = "Harghita", Locality = "Gheorgeni" };

            Keyword key1 = new Keyword { KeyWord = "csavarhuzo", KeywordProducts = new List<KeywordProduct>() };
            Keyword key2 = new Keyword { KeyWord = "fogaskerek", KeywordProducts = new List<KeywordProduct>() };
            Keyword key3 = new Keyword { KeyWord = "kulcs", KeywordProducts = new List<KeywordProduct>() };

            KeywordProduct kp1 = new KeywordProduct { Keyword = key1, KeywordId = key1.Id };
            KeywordProduct kp2 = new KeywordProduct { Keyword = key2, KeywordId = key2.Id };
            KeywordProduct kp3 = new KeywordProduct { Keyword = key3, KeywordId = key3.Id };

            key1.KeywordProducts.Add(kp1);
            key2.KeywordProducts.Add(kp2);
            key3.KeywordProducts.Add(kp3);

            Category cat1 = new Category { Id = 1, IsActive = true, Name = "Main1" };
            Category cat2 = new Category { Id = 2, IsActive = true, Name = "Main2" };


            Category sub1 = new Category { Id = 3, IsActive = true, Name = "Sub1", Parent = cat1 };
            Category sub2 = new Category { Id = 4, IsActive = true, Name = "Sub2", Parent = cat1 };
            Category sub3 = new Category { Id = 5, IsActive = true, Name = "Sub3", Parent = cat2 };

            Product product1 = new Product { BuyPrice = 100, SalePrice = 125, Name = "Termek1", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp3 } };
            Product product2 = new Product { BuyPrice = 100, SalePrice = 125, Name = "Termek2", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp2 } };
            Product product3 = new Product { BuyPrice = 100, SalePrice = 125, Name = "Termek3", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp1 } };

            kp1.Product = product3;
            kp1.ProductId = product3.ProductId;
            kp2.Product = product2;
            kp2.ProductId = product2.ProductId;
            kp3.Product = product1;
            kp3.ProductId = product1.ProductId;
            /*
            modelBuilder.Entity<Category>(c =>
            {
                c.HasData(sub1);
                c.OwnsOne(o => o.Parent).HasData(cat1);
            });*/

            #endregion

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
