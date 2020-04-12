using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DataAccessLayer.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Cart> Carts { get; set; }
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


            Geo geo1 = new Geo { Id = 1, County = "Bihor", Locality = "Oradea" };
            Geo geo2 = new Geo { Id = 2, County = "Harghita", Locality = "Gheorgeni" };

            Keyword key1 = new Keyword { Id = 1, KeyWord = "csavarhuzo", KeywordProducts = new List<KeywordProduct>()};
            Keyword key2 = new Keyword { Id = 2, KeyWord = "fogaskerek", KeywordProducts = new List<KeywordProduct>()};
            Keyword key3 = new Keyword { Id = 3, KeyWord = "kulcs", KeywordProducts = new List<KeywordProduct>() };

            KeywordProduct kp1 = new KeywordProduct {  KeywordId = key1.Id };
            KeywordProduct kp2 = new KeywordProduct {  KeywordId = key2.Id };
            KeywordProduct kp3 = new KeywordProduct {  KeywordId = key3.Id };

            key1.KeywordProducts.Add(kp1);
            key2.KeywordProducts.Add(kp2);
            key3.KeywordProducts.Add(kp3);


            Category cat1 = new Category { Id = 1, IsActive = true, Name = "Main1" };
            Category cat2 = new Category { Id = 2, IsActive = true, Name = "Main2" };


            Category sub1 = new Category { Id = 3, IsActive = true, Name = "Sub1", ParentId = cat1.Id };
            Category sub2 = new Category { Id = 4, IsActive = true, Name = "Sub2", ParentId = cat1.Id };
            Category sub3 = new Category { Id = 5, IsActive = true, Name = "Sub3", ParentId = cat2.Id };

            Product product1 = new Product { Id = 1, BuyPrice = 100, SalePrice = 125, Name = "Termek1", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp3 } };
            Product product2 = new Product { Id = 2, BuyPrice = 100, SalePrice = 125, Name = "Termek2", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp2 } };
            Product product3 = new Product { Id = 3, BuyPrice = 100, SalePrice = 125, Name = "Termek3", Stock = 50, Category = sub3, KeywordProducts = new List<KeywordProduct> { kp1 } };

          
            kp1.ProductId = product3.Id;
            kp2.ProductId = product2.Id;
            kp3.ProductId = product1.Id;

            modelBuilder.Entity<Category>()
                .HasData(
                cat1, cat2,
                sub1, sub2, sub3
                );


            modelBuilder.Entity<Geo>()
                .HasData(
                geo1, geo2
                );

            modelBuilder.Entity<KeywordProduct>()
              .HasData(
              kp1, kp2, kp3
              );

            modelBuilder.Entity<Keyword>()
                .HasData(
                key1, key2, key3
                );


            //modelBuilder.Entity<Product>()
            //    .HasData(
            //    product1, product2, product3
            //    );
            #endregion

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
