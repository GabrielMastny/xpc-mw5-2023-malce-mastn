using System;
using Eshop.DAL.Context;
using Eshop.DAL.Entities;
using Eshop.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebAPI.Helpers;
using WebAPI.MappingProfiles;

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
            //services.AddAutoMapper(typeof(CategoryDbMappings));
            services.AddAutoMapper(typeof(ManufacturerMappings));
                
            services.AddScoped<IRepository<CommodityEntity>, CommodityRepository>();
            services.AddScoped<IRepository<CategoryEntity>, CategoryRepository>();
            services.AddScoped<IRepository<ManufacturerEntity>, ManufacturerRepository>();
            services.AddScoped<IRepository<ReviewEntity>, ReviewRepository>();
            services.AddDbContext<EshopContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
                app.UseHttpsRedirection();

            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
