using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreDetail> StoreDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 101" },
                    new Value { Id = 2, Name = "Value 102" },
                    new Value { Id = 3, Name = "Value 103" }
                );

            builder.Entity<Article>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Articles);

            builder.Entity<Photo>()
                .HasOne(a => a.Article)
                .WithMany(u => u.Photos);

            builder.Entity<Store>()
               .HasOne(s => s.Partner)
               .WithMany(p => p.Stores);

            builder.Entity<Product>()
               .HasOne(s => s.ProductGroup)
               .WithMany(p => p.Products);

            //chổ này để tạo khóa chính cho bảng StoreDetail với
            //primary key tạo từ 2 id trong bảng Product và bảng Store
            builder.Entity<StoreDetail>(x => x.HasKey(ua =>
                new {ua.StoreId, ua.ProductId}));

            builder.Entity<StoreDetail>()
                .HasOne(u => u.Store)
                .WithMany(a => a.StoreDetails)
                .HasForeignKey(u => u.StoreId);

            builder.Entity<StoreDetail>()
                .HasOne(a => a.Product)
                .WithMany(u => u.StoreDetails)
                .HasForeignKey(a => a.ProductId);

            builder.Entity<Order>()
                .HasOne(u => u.AppUser)
                .WithMany(a => a.Orders);

            //chổ này để tạo khóa chính cho bảng OrderHistory với
            //primary key tạo từ 2 id trong bảng Order và bảng StatusOrder
             builder.Entity<OrderHistory>(x => x.HasKey(ua =>
                new {ua.OrderId, ua.StatusOrderId}));

            builder.Entity<OrderHistory>()
                .HasOne(u => u.Order)
                .WithMany(a => a.OrderHistories)
                .HasForeignKey(u => u.OrderId);

            builder.Entity<OrderHistory>()
                .HasOne(a => a.StatusOrder)
                .WithMany(u => u.OrderHistories)
                .HasForeignKey(a => a.StatusOrderId);
        }
    }
}
