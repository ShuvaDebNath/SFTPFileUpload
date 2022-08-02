using Assignment.Entities.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFTPService
{
    public static class SFTPServiceRegistration
    {
        public static void AddSFTPServiceLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<SFTPContext>
                (options => options.UseNpgsql(config.GetConnectionString("FileSystemConnectionString")));

        }
    }
}
