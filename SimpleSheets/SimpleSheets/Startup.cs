using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleSheets.Data.Enums;
using SimpleSheets.Data.Impls;
using SimpleSheets.Data.Interface;
using SimpleSheets.Services.Impls;
using SimpleSheets.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Mvc;

namespace SimpleSheets
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
            var connectionDetails = new List<IConnectionDetail>();
            var connectionName = "TimeSheetsConnection";
            var connectionType = DbConnectionType.SqlServer;
            var connectionString = Configuration["TimeSheetsConnectionString"].ToString();
            connectionDetails.Add(new ConnectionDetail(connectionName,
                connectionType, connectionString));
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>
               (d => new DbConnectionFactory(connectionDetails));
            services.AddSingleton<IAdminRepo, AdminRepo>();
            services.AddSingleton<IAdminService, AdminService>();
            services.AddSingleton<IGenericRepo, GenericRepo>();
            services.AddSingleton<IGenericService, GenericService>();
            services.AddSingleton<ITimeSheetService, TimeSheetService>();
            services.AddSingleton<ITimeSheetRepo, TimeSheetRepo>();
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
          .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));
            services.AddRazorPages().AddMvcOptions(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                              .RequireAuthenticatedUser()
                              .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).AddMicrosoftIdentityUI();
            //services.AddControllersWithViews();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{controller=TimeSheet}/{action=Index}/{id?}");
            });
        }
    }
}
