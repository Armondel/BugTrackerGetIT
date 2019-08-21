using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BugTrackerGetIT.WebApp.Data;
using BugTrackerGetIT.WebApp.Models;
using BugTrackerGetIT.WebApp.Services;
using Newtonsoft.Json;

namespace BugTrackerGetIT
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().AddJsonOptions(options =>
	            {
		            options.SerializerSettings.DateFormatString = "MM/dd/yyyy HH:mm:ss";
	            }); ;

			services.AddAutoMapper(typeof(MappingProfile));
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
			    app.UseExceptionHandler("/Home/Error");
		    }

		    app.UseStaticFiles();

		    app.UseAuthentication();

		    app.UseMvc(routes =>
		    {
			    routes.MapRoute(
				    name: "default",
				    template: "{controller=Home}/{action=Index}/{id?}");
		    });
	    }
	}
}
