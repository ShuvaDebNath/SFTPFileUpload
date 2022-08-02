using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Entities.DBContexts;
using Assignment.Entities.DBModels;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.Repository
{
    public class FileUploadRepository : RepositoryBase<FileUploadInfo>, IFileUploadRepository
    {
        private readonly FileUploadDbContext _uploadDbContext;
        public FileUploadRepository(IServiceProvider serviceProvider)
        {
            // Resolved the dependency of DbContext as Scoped
            _uploadDbContext = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<FileUploadDbContext>();
            Initialize(_uploadDbContext);
        }
    }
}
