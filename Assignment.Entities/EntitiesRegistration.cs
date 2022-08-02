using Assignment.Entities.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
    public static class EntitiesRegistration 
    {
        public static void ConfigureSqlDBContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<FileUploadDbContext>
                (options => options.UseNpgsql(config.GetConnectionString("FileSystemConnectionString")));
          
        }

    }
}
