using Microsoft.EntityFrameworkCore;
using Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using Application.Articles;
using Domain;
using Microsoft.AspNetCore.Identity;
using API.Middleware;
using Application.Interfaces;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using FluentValidation.AspNetCore;
using AutoMapper;
using Infrastructure.Photos;
using Application.Photos;
using Microsoft.OpenApi.Models;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                //opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            //add CORS cho phép truy cập từ nhiều domain khác
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
                });
            });
            //chúng ta có nhiều Handler, nhưng nhờ MediatR add 1 lần trong service
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(List.Handler));
            services.AddControllers(opt =>{
                var policy =  new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                opt.Filters.Add(new AuthorizeFilter(policy));
            })
                .AddFluentValidation(cfg =>{
                    cfg.RegisterValidatorsFromAssemblyContaining<Create>();
                });

            var builder = services.AddIdentityCore<AppUser>();
            //var builder = services.AddDefaultIdentity<AppUser>().AddRoles<IdentityRole>();
            var indentityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            indentityBuilder.AddEntityFrameworkStores<DataContext>();
            indentityBuilder.AddSignInManager<SignInManager<AppUser>>();

            // services.AddAuthorization(opt =>{
            //     opt.AddPolicy("IsArticleHost", policy =>{
            //         policy.Requirements.Add(new IsHostRequirement()); 
            //     });
            // });
            // services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>{
                    opt.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });
            services.AddScoped<IJwtGenerator, JwtGenerator>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.Configure<CloudinarySettings>(Configuration.GetSection("Cloudinary"));

             services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "API Tien Docs", Version = "v1" });
                //dòng này dùng để nếu 2 class có cùng namespace nó k bị lỗi schemeId
                options.CustomSchemaIds(x => x.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseRouting();
            //do add bên service nên add thêm ở đây gọi là middleware
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            //xác thực trước rồi mới phân quyền
            app.UseAuthorization();
         
            //routing phải trước endpoint
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });          
        }
    }
}
