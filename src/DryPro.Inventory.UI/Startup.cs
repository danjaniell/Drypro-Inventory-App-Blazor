using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using FluentValidation;
using MudBlazor.Services;
using DryPro.Inventory.Infrastructure.DbContexts;
using DryPro.Inventory.Core.Services.Base;
using DryPro.Inventory.Core.Services;
using DryPro.Inventory.Infrastructure.Repositories.Base;
using DryPro.Inventory.Infrastructure.Repositories;
using DryPro.Inventory.Core.Entities;
using DryPro.Inventory.Application.Validators;

namespace DryPro.Inventory.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("PostgreSQL"), x => x.MigrationsAssembly("DryPro.Inventory.Infrastructure")), ServiceLifetime.Transient);
            services.AddHttpContextAccessor();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IRepositoryManager, RepositoryManager>();
            services.AddFluentValidation();
            services.AddTransient<IValidator<Product>, ProductValidator>();
            services.AddTransient<IValidator<Parts>, PartValidator>();
            services.AddTransient<IValidator<Core.Entities.Inventory>, InventoryValidator>();
            services.AddMudServices();
            services.AddRazorPages();
            services.AddServerSideBlazor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
