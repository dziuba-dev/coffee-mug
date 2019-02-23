using CoffeeMug.API.ActionFilters;
using CoffeeMug.Core.Domain;
using CoffeeMug.Core.Repositories;
using CoffeeMug.Infrastructure.Commands;
using CoffeeMug.Infrastructure.Mappers;
using CoffeeMug.Infrastructure.Repositories;
using CoffeeMug.Infrastructure.Services;
using CoffeeMug.Infrastructure.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CoffeeMug.API
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
            services.AddDbContext<ProductDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ProductDatabase"),
                    x => x.MigrationsAssembly("CoffeeMug.API")));
            services.AddMvc(opt => 
                {
                    opt.Filters.Add(typeof(ValidationActionFilter));
                }).AddFluentValidation()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x => x.SerializerSettings.Formatting = Formatting.Indented);

            services.AddTransient<IValidator<CreateProduct>, CreateProductValidator>();
            services.AddTransient<IValidator<UpdateProduct>, UpdateProductValidator>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductServic, ProductServic>();

            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
