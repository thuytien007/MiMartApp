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
                context.SaveChanges();
            }

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com",
                        Avatar = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586959500/bu0ri90mobbkonaxblk5.jpg"

                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com",
                        Avatar = ""
                    },
                    new AppUser
                    {
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
                context.SaveChanges();
            }

            if (!context.UserRoles.Any())
            {
                var userRoles = new List<IdentityUserRole<string>>
                {
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(r => r.Email == "bob@test.com").Id,
                        RoleId = context.Roles.Single(r => r.Name == "Admin").Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(r => r.Email == "jane@test.com").Id,
                        RoleId = context.Roles.Single(r => r.Name == "Admin").Id
                    },
                    new IdentityUserRole<string>
                    {
                        UserId = context.Users.Single(r => r.Email == "tom@test.com").Id,
                        RoleId = context.Roles.Single(r => r.Name == "Chef").Id
                    }
                };
                context.UserRoles.AddRange(userRoles);
                context.SaveChanges();
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
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586959500/bu0ri90mobbkonaxblk5.jpg",
                        AppUser = context.Users.Single(r => r.Email == "jane@test.com"),
                    },
                    new Article
                    {
                        Title = "Canh chua cá lóc",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586970271/fbybitqqlqtvjgnnobzj.jpg",
                    },
                    new Article
                    {
                        Title = "Cá rô kho tộ",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586970286/kzpbbbi8ashc0vynosnh.png",
                        AppUser = context.Users.Single(r => r.Email == "jane@test.com"),

                    },
                    new Article
                    {
                        Title = "Gà nấu lá é",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1586839463/topfejocrjdxyrsnlxcc.jpg",
                    },
                };
                await context.Articles.AddRangeAsync(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}