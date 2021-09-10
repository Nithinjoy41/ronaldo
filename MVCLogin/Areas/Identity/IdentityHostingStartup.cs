using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCLogin.Areas.Identity.Data;
using MVCLogin.Data;

[assembly: HostingStartup(typeof(MVCLogin.Areas.Identity.IdentityHostingStartup))]
namespace MVCLogin.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MVCDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MVCDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>  { options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<MVCDBContext>();
            });
        }
    }
}