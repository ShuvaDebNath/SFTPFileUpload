using System.Data;
using Assignment.Entities.DBModels;
using Assignment.Repository;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace Assignment.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        private readonly ISftpService _sftpService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<FileUploadService> _logger;
        public FileUploadService(IFileUploadRepository fileUploadRepository, 
                                 ISftpService sftpService, 
                                 IConfiguration configuration,
                                 ILogger<FileUploadService> logger
                                 )
        {
            _fileUploadRepository = fileUploadRepository;
            _sftpService = sftpService;
            _configuration = configuration;
            _logger = logger;
        }

        public string CheckNewFileExistOrNot()
        {
            var sftpService = new SftpService(new NullLogger<SftpService>(), _configuration);

            #region Get all the file list from remote directory
            var remoteFilePath = sftpService.ListAllFiles();
            #endregion

            #region Initial Variable
            bool isInformationSaved, isDownloadSuccessed = false;
            string remoteFileName = "";
            List<bool> statusArray = new();
            #endregion

            foreach (var file in remoteFilePath)
            {
                // for some unknown file, check the length first
                if (file.Length > 0)
                {
                    remoteFileName = file.Name;

                    #region For getting file type
                    var splitExtension = file.FullName.Split('.');
                    var remoteFileType = splitExtension[splitExtension.Length - 1].ToString();
                    #endregion

                    # region check file name exists or not

                    var getResult = _fileUploadRepository.SingleOrDefault(a => a.FileName == remoteFileName);
                    #endregion

                    if (getResult == null)
                    {
                        FileUploadInfo fileUploadInfos = new()
                        {
                            FilePath = "/",
                            FileName = remoteFileName,
                            FileType = remoteFileType
                        };

                        isInformationSaved = SaveFileUploadInfo(fileUploadInfos);

                        var createLocalDestinationFilename = "/downloads/" + remoteFileName;

                        isDownloadSuccessed = sftpService.DownloadFile(remoteFileName, createLocalDestinationFilename);

                        if (isInformationSaved && isDownloadSuccessed)
                        {
                            statusArray.Add(isInformationSaved);
                        }                       
                    }
                }
            }
            //count the number of true status if data will insert in the database.
            var count = statusArray.Where(x => x == true).Count();

            _logger.LogInformation("Total Data Saved : {0} ", count.ToString());

            return count.ToString();
        }

        public bool SaveFileUploadInfo(FileUploadInfo fileUploadInfo)
        {
            try
            {
                _fileUploadRepository.Create(fileUploadInfo);

                return _fileUploadRepository.SaveChange() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

        }
    }
}
