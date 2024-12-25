using Karus.Application.Contracts;
using Karus.Data.AzureStorageTables.Entities;
using Karus.Data.AzureStorageTables.Repos;
using Karus.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Karus.Data.AzureStorageTables.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddKarusDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRepo<Quote, Guid>>(serviceProdider =>
        {
            var options = serviceProdider.GetRequiredService<IOptions<AzureOptions>>().Value;
            var logger = serviceProdider.GetRequiredService<ILogger<BaseRepo<QuoteEntity, Guid>>>();
            return new QuotesRepo(logger, options.Storage.ConnectionString, "KarusQuotes");
        });

        return services;
    }
}
