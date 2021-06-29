using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModulosUsuario.Contexts;
using ModulosUsuario.Interfaces.Repositories;
using ModulosUsuario.Interfaces.Services;
using ModulosUsuario.Repositories;
using ModulosUsuario.Services;

namespace ModulosUsuario
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
            services.AddControllersWithViews();

            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnityTypeService, UnityTypeService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IToolsService, ToolsService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IPaymentService, PaymentService>();

            //repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnityTypeRepository, UnityTypeRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IToolsRepository, ToolsRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IMaterialTransactionRepository, MaterialTransactionRepository>();
            services.AddScoped<IProductTransactionRepository, ProductTransactionRepository>();
            services.AddScoped<IToolsTransactionRepository, ToolsTransactionRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();

            //database
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext databaseContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            databaseContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
