using Microsoft.EntityFrameworkCore;
using Assignment.Entities.DBModels;

namespace Assignment.Entities.DBContexts
{
    public class FileUploadDbContext : DbContext
    {
        public FileUploadDbContext(DbContextOptions<FileUploadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<FileUploadInfo> FileUploadInfos { get; set; }
    }
}
