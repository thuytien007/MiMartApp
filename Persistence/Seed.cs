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
                        RoleId = context.Roles.Single(r => r.Name == "User").Id
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
                        AppUser = context.Users.Single(r => r.Email == "tom@test.com"),
                    },
                    new Article
                    {
                        Title = "Canh chua cá lóc",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589265331/canhchuacaloc_wynebe.jpg",
                        AppUser = context.Users.Single(r => r.Email == "bob@test.com"),
                    },
                    new Article
                    {
                        Title = "Cá rô kho tộ",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589265308/cakhoto_vskrmw.jpg",
                        AppUser = context.Users.Single(r => r.Email == "tom@test.com"),

                    },
                    new Article
                    {
                        Title = "Gà nấu lá é",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Chuẩn bị nguyên liệu: hành, ngò, ..v..v",
                        Image = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589265321/ganaulae_icotng.jpg",
                        AppUser = context.Users.Single(r => r.Email == "bob@test.com"),
                    },
                };
                context.Articles.AddRange(articles);
                context.SaveChanges();
            }
            // if (!context.Photos.Any())
            // {
            //      var photo = new List<Photo>
            //      {
            //         new Photo
            //         {
            //             Url = "",
            //             isMain = false,
            //         }
            //      };
            // }
            if (!context.Partners.Any())
            {
                var partner = new List<Partner>
                {
                    new Partner
                    {
                        PartnerName = "Bách Hóa Xanh",
                        Logo = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589338128/bach-hoa-xanh_splbat.png",
                    },
                    new Partner
                    {
                        PartnerName = "Vinmart",
                        Logo = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589338412/vinmart_vzt0uz.png",
                    },
                    new Partner
                    {
                        PartnerName = "Co.op Food",
                        Logo = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589338605/co.op-food_ma9m0s.png",
                    },
                };
                context.Partners.AddRange(partner);
                context.SaveChanges();
            }
            if (!context.ProductGroups.Any())
            {
                var group = new List<ProductGroup>
                {
                    new ProductGroup
                    {
                        GroupName = "Hải Sản",
                    },
                     new ProductGroup
                    {
                        GroupName = "Đồ Hộp",
                    },
                     new ProductGroup
                    {
                        GroupName = "Mì",
                    }
                };
                context.ProductGroups.AddRange(group);
                context.SaveChanges();
            }
            if (!context.Products.Any())
            {
                var product = new List<Product>
                {
                    new Product
                    {
                        ProductName = "Tôm Sú AG",
                        CalculationUnit = "kg",
                        Description = "Tôm sông, tôm tươi thuộc cty thực phẩm AG",
                        Instructions = "Có thể làm các món nướng, kho tàu, nấu lẩu",
                        ManufacturingDate = DateTime.Now.AddMonths(-2),
                        ExpiryDate = DateTime.Now.AddMonths(2),
                        ProductImage = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589477332/tom-su_mnl7ku.jpg",
                        ProductGroup = context.ProductGroups.Single(r => r.GroupName == "Hải Sản"),

                    },
                     new Product
                    {
                        ProductName = "Mì Hảo Hảo Chua Cay",
                        CalculationUnit = "gói",
                        Description = "Mì ăn liền vị tôm chua cay của cty CP Hảo Hảo",
                        Instructions = "Cho mì và gói nêm + dầu vào tô, cho nước sôi vào, đậy nắp 2p, hoặc ăn sống",
                        ManufacturingDate = DateTime.Now.AddMonths(-1),
                        ExpiryDate = DateTime.Now.AddMonths(2),
                        ProductImage = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589477334/mi-hao-hao-chua-cay_h3v7eh.jpg",
                        ProductGroup = context.ProductGroups.Single(r => r.GroupName == "Mì"),
                    },
                     new Product
                    {
                        ProductName = "Cá Mòi 3 Cô Gái",
                        CalculationUnit = "hộp",
                        Description = "Cá mòi đóng hộp của cty CP Choika Thái Lan",
                        Instructions = "Phi tỏi vào chảo, cho cá mòi vào, nêm nếp gia vị phù hợp..v...v",
                        ManufacturingDate = DateTime.Now.AddMonths(-3),
                        ExpiryDate = DateTime.Now.AddMonths(3),
                        ProductImage = "https://res.cloudinary.com/dfnrna9e8/image/upload/v1589477333/ca-moi-ba-co-gai_oeirts.jpg",
                        ProductGroup = context.ProductGroups.Single(r => r.GroupName == "Đồ Hộp"),
                    }
                };
                context.Products.AddRange(product);
                context.SaveChanges();
            }
            if (!context.Stores.Any())
            {
                var store = new List<Store>
                {
                    new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Bách Hóa Xanh"),
                        District = "Quận 2",
                        Address = "419 Nguyễn Thị Định, Cát Lái",
                        Coordinates = "10.777722, 106.768918",
                        StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Mì Hảo Hảo Chua Cay"),
                                Price = 3000,
                                InventoryNumber = 1000,
                            },
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Cá Mòi 3 Cô Gái"),
                                Price = 15000,
                                InventoryNumber = 2000,
                            }
                        }
                    },
                    new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Bách Hóa Xanh"),
                        District = "Quận 8",
                        Address = "117 Âu Dương Lân, Phường 2",
                        Coordinates = "10.746256, 106.683224",
                        StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Mì Hảo Hảo Chua Cay"),
                                Price = 3500,
                                InventoryNumber = 500,
                            },
                        }
                    },
                     new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Vinmart"),
                        District = "Quận 7",
                        Address = "255 Trần Xuân Soạn, Tân Kiểng",
                        Coordinates = "10.752277, 106.714884",
                        StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Mì Hảo Hảo Chua Cay"),
                                Price = 3200,
                                InventoryNumber = 700,
                            },
                        }
                    },
                    new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Vinmart"),
                        District = "Quận 10",
                        Address = "584 Nguyễn Chí Thanh, Phường 7",
                        Coordinates = "10.759574, 106.659615",
                        StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Tôm Sú AG"),
                                Price = 300000,
                                InventoryNumber = 50,
                            },
                        }
                    },
                     new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Co.op Food"),
                        District = "Quận 8",
                        Address = "90 218 Cao Lỗ, Phường 4",
                        Coordinates = "10.736857, 106.677364",
                        StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Cá Mòi 3 Cô Gái"),
                                Price = 17000,
                                InventoryNumber = 800,
                            },
                        }
                    },
                     new Store
                    {
                        Partner = context.Partners.Single(n => n.PartnerName == "Co.op Food"),
                        District = "Quận 7",
                        Address = "102 Đường Số 15, Tân Quy",
                        Coordinates = "10.746713, 106.706773",
                         StoreDetails = new List<StoreDetail>
                        {
                            new StoreDetail
                            {
                                Product = context.Products.Single(n => n.ProductName == "Tôm Sú AG"),
                                Price = 250000,
                                InventoryNumber = 40,
                            },
                        }
                    }
                };
                context.Stores.AddRange(store);
                context.SaveChanges();
            }
            if (!context.StatusOrders.Any())
            {
                var statusOrder = new List<StatusOrder>
                {
                    new StatusOrder
                    {
                        Description = "Đặt hàng thành công"
                    },
                     new StatusOrder
                    {
                        Description = "Đang soạn hàng"
                    },
                     new StatusOrder
                    {
                        Description = "Đang giao hàng"
                    },
                     new StatusOrder
                    {
                        Description = "Giao hàng thành công"
                    },
                     new StatusOrder
                    {
                        Description = "Đơn hàng bị hủy"
                    }
                };
                context.StatusOrders.AddRange(statusOrder);
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                var order = new List<Order>
                {
                    new Order
                    {
                        DateOfOrder = new DateTime(2020, 03, 01, 09, 30, 20),
                        Total = 300000,
                        AppUser = context.Users.Single(e => e.Email == "jane@test.com"),
                        OrderHistories = new List<OrderHistory>
                        {
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 03, 01, 09, 30, 20),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đặt hàng thành công"),
                            },
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 03, 01, 10, 00, 05),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đang soạn hàng"),
                            },
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 03, 01, 10, 30, 05),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đang giao hàng"),
                            },
                             new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 03, 01, 10, 50, 05),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Giao hàng thành công"),
                            },
                        }
                    },
                    new Order
                    {
                        DateOfOrder = new DateTime(2020, 04, 01, 09, 30, 20),
                        Total = 500000,
                        AppUser = context.Users.Single(e => e.Email == "jane@test.com"),
                        OrderHistories = new List<OrderHistory>
                        {
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 04, 01, 09, 30, 20),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đặt hàng thành công"),
                            },
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 04, 01, 10, 00, 05),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đơn hàng bị hủy"),
                            },
                        }
                    },
                    new Order
                    {
                        DateOfOrder = new DateTime(2020, 05, 24, 09, 30, 20),
                        Total = 1000000,
                        AppUser = context.Users.Single(e => e.Email == "bob@test.com"),
                        OrderHistories = new List<OrderHistory>
                        {
                            new OrderHistory
                            {
                                DateOfStatusOrder = new DateTime(2020, 05, 24, 09, 30, 20),
                                StatusOrder = context.StatusOrders.Single(m => m.Description == "Đặt hàng thành công"),
                            },
                        }
                    },
                };
                context.Orders.AddRange(order);
                context.SaveChanges();
            }
        }
    }
}