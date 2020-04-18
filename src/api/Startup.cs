using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using domain.entities;
using domain.interfaces;
using infra.database;
using service.repositories;
using service.services;

namespace api
{
    public class Startup
    {
        const string MY_ALLOW_SPECIFIC_ORIGINS = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DotNetEnv.Env.Load();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    name: MY_ALLOW_SPECIFIC_ORIGINS,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.Configure<KestrelServerOptions>(
                Configuration.GetSection("Kestrel")
            );

            services.AddControllers();
            services.AddScoped<IEntityRepository<Menu>, MockMenuRepository>();
            services.AddScoped<IEntityRepository<Order>, BaseRepository<Order>>();
            services.AddSingleton<DbContext, OrderContext>(_ =>
            {
                var options = new DbContextOptionsBuilder<OrderContext>()
                    .UseInMemoryDatabase(databaseName: "inMemoryOrderDb")
                    .Options;

                return new OrderContext(options);
            });
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IMenuService, MockedMenuService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MY_ALLOW_SPECIFIC_ORIGINS);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}