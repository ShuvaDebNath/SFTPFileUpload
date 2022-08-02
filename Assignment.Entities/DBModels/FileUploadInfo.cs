using System.ComponentModel.DataAnnotations.Schema;
using Assignment.Entities.Common;

namespace Assignment.Entities.DBModels
{
    [Table("fileUploadInfo")]
    public class FileUploadInfo : BaseEntity
    {
        [Column("filepath")]
        public string? FilePath { get; set; }

        [Column("filename")]
        public string? FileName { get; set; }

        [Column("filetype")]
        public string? FileType { get; set; }
    }
}
