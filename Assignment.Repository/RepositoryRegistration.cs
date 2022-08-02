using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Repository
{
    public static class RepositoryRegistration
    {
        public static void AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddTransient<IFileUploadRepository, FileUploadRepository>();

        }
    }
}
