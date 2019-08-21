using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BugTrackerGetIT.WebApp.Data;
using BugTrackerGetIT.Core.User;
using BugTrackerGetIT.WebApp.Configurations;
using BugTrackerGetIT.Persistence;

namespace BugTrackerGetIT
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().AddJsonOptions(options =>
	            {
		            options.SerializerSettings.DateFormatString = "MM/dd/yyyy HH:mm:ss";
	            }); ;

			services.AddAutoMapper(typeof(MappingProfile));
        }

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
