using Karus.Application.Contracts;
using Karus.Data.AzureStorageTables.Configuration;
using Karus.Infrastucture.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Karus.Infrastucture.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddKarusInstrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKarusOptions(configuration);

        services.AddScoped<IFileReader, FileReader>();
        services.AddScoped<IOpdrachtItemsService, OpdrachtItemsService>();

        var azureOptions = services.BuildServiceProvider().GetRequiredService<IOptions<AzureOptions>>().Value;
        string storageConnectionString = azureOptions.Storage.ConnectionString;

        return services;
    }


    #region Helpers

    private static IServiceCollection AddKarusOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureOptions>(
            configuration.GetSection(AzureOptions.SectionName));

        return services;
    }

    #endregion "Helpers"
}