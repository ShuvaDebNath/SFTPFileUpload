using Microsoft.Extensions.Logging;
using Renci.SshNet.Sftp;
using Renci.SshNet;
using Microsoft.Extensions.Configuration;

namespace Assignment.Service
{
    public class SftpService : ISftpService
    {
        private readonly ILogger<SftpService> _logger;
        private IConfiguration _configuration;

        public SftpService(ILogger<SftpService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IEnumerable<SftpFile> ListAllFiles(string remoteDirectory = ".")
        {
            SftpClient client = SftpConfiguration();

            try
            {
                client.Connect();
                return client.ListDirectory(remoteDirectory);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in listing files under [{remoteDirectory}]");
                return null;
            }
            finally
            {
                client.Disconnect();
            }
        }
        public bool DownloadFile(string remoteFilePath, string localFilePath)
        {
            SftpClient client = SftpConfiguration();

            try
            {
                client.Connect();
                using var s = File.Create(localFilePath);
                client.DownloadFile(remoteFilePath, s);
                _logger.LogInformation($"Finished downloading file [{localFilePath}] from [{remoteFilePath}]");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Failed in downloading file [{localFilePath}] from [{remoteFilePath}]");
                return false;
            }
            finally
            {
                client.Disconnect();
            }
            return true;
        }


        private SftpClient SftpConfiguration()
        {
            var getUserName = _configuration.GetSection("SFTP").GetSection("UserName").Value;
            var getPassword = _configuration.GetSection("SFTP").GetSection("Password").Value;
            var getPort = Convert.ToInt32(_configuration.GetSection("SFTP").GetSection("Port").Value);
            var getHost = _configuration.GetSection("SFTP").GetSection("Host").Value;
            var client = new SftpClient(
                                                        getHost,
                                                        getPort,
                                                        getUserName,
                                                        getPassword);
            return client;
        }
    }
}
