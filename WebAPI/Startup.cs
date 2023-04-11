using System;
using App.DAL.Entities;
using CommonDbProperties.Interfaces.Repositories;
using EFDb.Context;
using EFDb.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAPI.Helpers;
using WebAPI.MappingProfiles;
using MemDB = App.DAL.Repositories;
using EFDB = EFDb.Repositories;

namespace WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddVersioning();
            services.AddAutoMapper(typeof(CommodityMappings));
            services.AddAutoMapper(typeof(CategoryMappings));
            services.AddAutoMapper(typeof(ManufacturerMappings));
            if (Environment.GetEnvironmentVariable("DB_Type") == "EFDb")
            {
                services.AddAutoMapper(typeof(CategoryDbMappings));
                services.AddAutoMapper(typeof(ManufacturerMappings));
                
                services.AddScoped<IRepository<CommodityEntity>, EFDB.CommodityRepository>();
                services.AddScoped<IRepository<CategoryEntity>, EFDB.CategoryRepository>();
                services.AddScoped<IRepository<ManufacturerEntity>, EFDB.ManufacturerRepository>();
                services.AddScoped<IRepository<ReviewEntity>, EFDB.ReviewRepository>();
                services.AddDbContext<EshopContext>();
                
            }
            else
            {
                services.AddScoped<IRepository<CommodityEntity>, MemDB.CommodityRepository>();
                services.AddScoped<IRepository<CategoryEntity>, MemDB.CategoryRepository>();
                services.AddScoped<IRepository<ManufacturerEntity>, MemDB.ManufacturerRepository>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
