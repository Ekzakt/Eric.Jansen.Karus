using Karus.Application.Contracts;
using Karus.Application.Dtos;
using Karus.Application.Services;
using Karus.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Karus.Application.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddKarusApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddKarusOptions(configuration);

        services.AddScoped<IGenericService<QuoteDto, Guid>>(serviceProdider =>
        {
            var repo = serviceProdider.GetRequiredService<IRepo<Quote, Guid>>();
            return new QuotesService(repo);
        });

        return services;
    }


    #region Helpers

    private static IServiceCollection AddKarusOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KarusOptions>(
            configuration.GetSection(KarusOptions.SectionName).Bind);

        return services;
    }

    #endregion "Helpers"



}
