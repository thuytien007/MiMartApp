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
        public DbSet<Activity> Activities { get; set; }
        public DbSet<UserActivity> UserActivities {get; set;}
        public DbSet<Photo> Photos {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //câu lệnh này để khi chạy migrations lên sẽ tạo cho AppUser 1 khóa chính
            base.OnModelCreating(builder);
            builder.Entity<Value>()
                .HasData(
                    new Value { Id = 1, Name = "Value 101" },
                    new Value { Id = 2, Name = "Value 102" },
                    new Value { Id = 3, Name = "Value 103" }
                );
            
            //chổ này để tạo khóa chính cho bảng UserActivity với
            //primary key tạo từ 2 id trong bảng Activity và bảng AppUser
            builder.Entity<UserActivity>(x => x.HasKey(ua =>
                new {ua.AppUserId, ua.ActivityId}));

            //chổ này gọi là define relationshops
            builder.Entity<UserActivity>()
                .HasOne(u => u.AppUser)//1 user
                .WithMany(a => a.UserActivities)//có nhiều useractivity
                .HasForeignKey(u => u.AppUserId);//thông qua AppUserId

            builder.Entity<UserActivity>()
                .HasOne(a => a.Activity) //1 activity
                .WithMany(u => u.UserActivities)//có nhiều useractivity
                .HasForeignKey(a => a.ActivityId);
        }
    }
}
