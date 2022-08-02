using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Entities.DBModels;

namespace Assignment.Service
{
    public interface IFileUploadService
    {
        string CheckNewFileExistOrNot();
        bool SaveFileUploadInfo(FileUploadInfo fileUploadInfo);
    }
}
