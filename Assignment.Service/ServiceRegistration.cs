using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Service
{
    public static class ServiceRegistration
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddTransient<IFileUploadService, FileUploadService>();
            services.AddTransient<ISftpService, SftpService>();

        }
    }
}
