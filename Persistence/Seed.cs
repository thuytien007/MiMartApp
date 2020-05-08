using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        Id = "a",
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com",
                        Avatar = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586959500/bu0ri90mobbkonaxblk5.jpg"
                    },
                    new AppUser
                    {
                        Id = "b",
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com",
                        Avatar = ""
                    },
                    new AppUser
                    {
                        Id = "c",
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com",
                        Avatar = ""
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            if (!context.Roles.Any())
            {
                string[] roles = new string[] { "Admin", "User", "Chef", "Shop Manager" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }
            }
            if (!context.Articles.Any())
            {
                var articles = new List<Article>
                {
                    new Article
                    {
                        Title = "Cá chiên sốt cà",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Author= "Nguyễn Văn A",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586959500/bu0ri90mobbkonaxblk5.jpg",
                    },
                    new Article
                    {
                        Title = "Canh chua cá lóc",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Author= "Trần văn B",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586970271/fbybitqqlqtvjgnnobzj.jpg",
                    },
                    new Article
                    {
                        Title = "Cá rô kho tộ",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Author= "Phan thị C",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586970286/kzpbbbi8ashc0vynosnh.png",

                    },
                    new Article
                    {
                        Title = "Gà nấu lá é",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Author= "Hello Kitty",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586839463/topfejocrjdxyrsnlxcc.jpg",
                    },
                };
                await context.Articles.AddRangeAsync(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}