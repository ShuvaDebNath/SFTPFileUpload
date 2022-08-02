using Assignment.Entities.DBModels;
using Assignment.Service;
using Microsoft.Extensions.Logging.Abstractions;

namespace Assignment.App
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IFileUploadService _fileUploadService;
        
        public Worker(ILogger<Worker> logger, IFileUploadService fileUploadService)
        {
            _logger = logger;
            _fileUploadService = fileUploadService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _fileUploadService.CheckNewFileExistOrNot();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000 * 5, stoppingToken);               
                
            }
        }
    }
}