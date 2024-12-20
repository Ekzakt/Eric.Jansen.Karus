using Karus.Application.Configuration;
using Karus.Application.Contracts;
using Karus.Infrastucture.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Karus.Infrastucture.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddKarusServices(this WebApplicationBuilder builder)
    {
        builder.AddKarusOptions();

        builder.Services.AddScoped<IFileReader, FileReader>();
        builder.Services.AddScoped<IOpdrachtItemsService, OpdrachtItemsService>();

        return builder;
    }


    private static WebApplicationBuilder AddKarusOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<KarusOptions>(
            builder.Configuration.GetSection(KarusOptions.SectionName));

        return builder;
    }
}
