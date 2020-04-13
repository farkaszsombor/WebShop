using Entities;
using Microsoft.EntityFrameworkCore;
using System;

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
            #region data
            Geo geo1 = new Geo { Id = 1, County = "Bihor", Locality = "Oradea" };
            Geo geo2 = new Geo { Id = 2, County = "Harghita", Locality = "Gheorgeni" };

            Card card1 = new Card { Id = 1, Holder = "Kiscsillag", Number = "hahahaha", Cvv = 000, ExpirationDate = new DateTime().AddDays(12).AddYears(10) };
            Card card2 = new Card { Id = 2, Holder = "Pikans", Number = "hahahaha", Cvv = 000, ExpirationDate = new DateTime().AddDays(12).AddYears(5) };

            User user1 = new User { Id = 1, FirstName = "Farkas", LastName = "Zsombor", Email = "asd@asd.com", Address = "WTF", PasswordHash = "ZSFSAFASFS", OrdersCount = 0, PhoneNumber = "nincs", GeoId = 1, CardId = 1, CartId = 1,ReviewId = 1};
            User user2 = new User { Id = 2, FirstName = "Rapa", LastName = "Erik", Email = "asd@asd.com", Address = "WTF", PasswordHash = "ZSFSAFASFS", OrdersCount = 0, PhoneNumber = "nincs", GeoId = 2, CardId = 2, CartId = 2, ReviewId = 2 };

            CartProduct cartProduct1 = new CartProduct { CartId = 1, ProductId = 1 };
            CartProduct cartProduct2 = new CartProduct { CartId = 2, ProductId = 1 };

            Cart cart1 = new Cart { Id = 1, SubTotal = 123 };
            Cart cart2 = new Cart { Id = 2, SubTotal = 123 };

            Product product1 = new Product { Id = 1, Name = "Csavarhuzo", BuyPrice = 12, SalePrice = 10, ProductCode = "asd", ImportCountryCode = "JPN", OrderLink = "hosszu", Stock = 10, ShortDescription = "a", LongDescription = "aaaaa", Type = "kesztyu", CategoryId = 1, ParentId = 1};
            Product product2 = new Product { Id = 2, Name = "Csavarhuszo", BuyPrice = 12, SalePrice = 10, ProductCode = "assssd", ImportCountryCode = "JPNA", OrderLink = "hosszu", Stock = 10, ShortDescription = "a", LongDescription = "aaaaa", Type = "kesztyu", CategoryId = 2, ParentId = 2};

            Category category1 = new Category { Id = 1, IsActive = true, Name = "alma", ParentId = 1 };
            Category category2 = new Category { Id = 2, IsActive = true, Name = "alma", ParentId = 1 };

            Image image1 = new Image { Id = 1, Alt = "asd", FileName = "long", Path = "bumm", ProductId = 1 }; 
            Image image2 = new Image { Id = 2, Alt = "asd", FileName = "long", Path = "bumm", ProductId = 1 };

            Keyword keyword1 = new Keyword { Id = 1, KeyWord = "bicska", KeywordProductId = 1 };
            Keyword keyword2 = new Keyword { Id = 2, KeyWord = "bicskav2", KeywordProductId = 2};

            KeywordProduct keywordProduct1 = new KeywordProduct { KeywordId = 1, ProductId = 1 };
            KeywordProduct keywordProduct2 = new KeywordProduct { KeywordId = 1, ProductId = 2 };

            Review review1 = new Review { Id = 1, ProductId = 1, ReviewText = "blablA", Stars = 3 };
            Review review2 = new Review { Id = 2, ProductId = 2, ReviewText = "blasblA", Stars = 3 };

            #endregion

            #region tableBuilder
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(user => user.Id);
                builder.HasOne(o => o.Geo).WithOne(o => o.User).HasForeignKey<User>(fk => fk.GeoId);
                builder.HasOne(o => o.Card).WithOne(o => o.User).HasForeignKey<User>(fk => fk.CardId);
                builder.HasOne(o => o.Cart).WithOne(o => o.User).HasForeignKey<User>(fk => fk.CartId);
                builder.HasOne(o => o.Review).WithOne(o => o.User).HasForeignKey<User>(fk => fk.ReviewId);
                builder.HasData(user1, user2);
            });

            modelBuilder.Entity<Geo>(builder => 
            {
                builder.HasKey(geo => geo.Id);
                builder.HasData(geo1, geo2);
            });

            modelBuilder.Entity<Card>(builder =>
            {
                builder.HasKey(card => card.Id);
                builder.HasData(card1, card2);
            });

            modelBuilder.Entity<Cart>(builder =>
            {
                builder.HasKey(cart => cart.Id);
                builder.HasData(cart1, cart2);
            });

            modelBuilder.Entity<CartProduct>(builder =>
            {
                builder.HasKey(cartproduct => new { cartproduct.CartId, cartproduct.ProductId });
                builder.HasOne(o => o.Cart).WithMany(m => m.CartProducts).HasForeignKey(fk => fk.CartId);
                builder.HasOne(o => o.Product).WithMany(m => m.CartProducts).HasForeignKey(fk => fk.ProductId);
                builder.HasData(cartProduct1, cartProduct2);
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(product => product.Id);
                builder.HasOne(o => o.Category).WithOne(o => o.Product).HasForeignKey<Product>(fk => fk.CategoryId);
                builder.HasMany(o => o.Images).WithOne(o => o.Product).HasForeignKey(fk => fk.ProductId);
                builder.HasOne(o => o.Parent).WithOne().HasForeignKey<Product>(fk => fk.ParentId).OnDelete(DeleteBehavior.NoAction);
                builder.HasData(product1, product2);
            });

            modelBuilder.Entity<Category>(builder => 
            {
                builder.HasKey(category => category.Id);
                builder.HasOne(o => o.Parent).WithOne().HasForeignKey<Category>(fk => fk.ParentId).OnDelete(DeleteBehavior.NoAction);
                builder.HasData(category1, category2);
            });

            modelBuilder.Entity<Image>(builder =>
            {
                builder.HasKey(iamge => iamge.Id);
                builder.HasData(image1, image2);
            });

            modelBuilder.Entity<Keyword>(builder =>
            {
                builder.HasKey(keyword => keyword.Id);
                builder.HasData(keyword1, keyword2);
            });

            modelBuilder.Entity<KeywordProduct>(builder =>
            {
                builder.HasKey(keywordProduct => new { keywordProduct.KeywordId, keywordProduct.ProductId});
                builder.HasOne(o => o.Product).WithMany(o => o.KeywordProducts).HasForeignKey(fk => fk.ProductId);
                builder.HasOne(o => o.Keyword).WithMany(o => o.KeywordProducts).HasForeignKey(fk => fk.KeywordId);
                builder.HasData(keywordProduct1, keywordProduct2);
            });

            modelBuilder.Entity<Review>(builder =>
            {
                builder.HasKey(review => review.Id);
                builder.HasOne(o => o.Product).WithMany(o => o.Reviews).HasForeignKey(fk => fk.ProductId);
                builder.HasData(review1, review2);
            });
            #endregion
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
