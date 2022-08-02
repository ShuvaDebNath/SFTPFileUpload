using Assignment.App;
using Assignment.Entities;
using Assignment.Entities.DTO_s;
using Assignment.Repository;
using Assignment.Service;
using Microsoft.Extensions.Options;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((host, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddServiceLayer();
        services.ConfigureSqlDBContext(host.Configuration);
        services.AddRepositoryLayer();
        services.Configure<SftpConfig>(host.Configuration.GetSection("SFTP"));
    })
    .Build();

await host.RunAsync();
