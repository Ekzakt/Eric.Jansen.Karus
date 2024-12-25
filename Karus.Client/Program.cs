using Karus.Application.Configuration;
using Karus.Data.AzureStorageTables.Configuration;
using Karus.Infrastucture.Configuration;

namespace Karus.Client;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddKarusApplicationServices(builder.Configuration);
        builder.Services.AddKarusInstrastructureServices(builder.Configuration);
        builder.Services.AddKarusDataServices(builder.Configuration);

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
