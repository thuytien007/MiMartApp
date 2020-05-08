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
        public DbSet<UserArticle> UserArticles {get; set;}
        public DbSet<Photo> Photos {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 101" },
                    new Value { Id = 2, Name = "Value 102" },
                    new Value { Id = 3, Name = "Value 103" }
                );
            
            //chổ này để tạo khóa chính cho bảng UserArticle với
            //primary key tạo từ 2 id trong bảng Article và bảng AppUser
            builder.Entity<UserArticle>(x => x.HasKey(ua =>
                new {ua.AppUserId, ua.ArticleId}));

            builder.Entity<UserArticle>()
                .HasOne(u => u.AppUser)//có nhiều AppUser
                .WithMany(a => a.UserArticles)//1 Article
                .HasForeignKey(u => u.AppUserId);//thông qua AppUserId

            builder.Entity<UserArticle>()
                .HasOne(a => a.Article)
                .WithMany(u => u.UserArticles)
                .HasForeignKey(a => a.ArticleId);
        }
    }
}
