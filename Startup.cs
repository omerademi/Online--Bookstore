using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookStore.Services.Service.Interfaces;
using BookStore.Data.Entities;
using BookStore.Services;
using BookStore.Repositories.Repository.Interfaces;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BookStore
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
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookstoreConnection")));  //DefaultConnection
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>() // Add Identity roles for restraining the views
                .AddEntityFrameworkStores<DataContext>(); // ApplicationDbContext
            services.AddControllersWithViews();
            services.AddRazorPages();
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddRazorPagesOptions(options =>
            {
                //options.AllowAreas = true;
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IWishlistRepository, WishlistRepository>();
            services.AddTransient<IBookSearchRepository, BookSearchRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPreOrderRepository, PreOrderRepository>();

            // Email Config
            services.AddSingleton<IEmailConfiguration>(Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

            // Admin User Settings
            // services.AddSingleton<IAdminUserSettings>(Configuration.GetSection("AppSettings").Get<AdminUserSettings>());

            // Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IWishlistService, WishlistService>();
            services.AddTransient<IBookSearchService, BookSearchService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IPreOrderService, PreOrderService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
