using Karus.Application.Contracts;
using Karus.Application.Dtos;
using Karus.Domain.Models;
using Karus.Infrastucture.Mappers;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Karus.Infrastucture.Services;

public class OpdrachtItemsService : IOpdrachtItemsService
{
    private readonly ILogger<OpdrachtItemsService> _logger;
    private readonly IFileReader _fileReader;


    public OpdrachtItemsService(
        ILogger<OpdrachtItemsService> logger,
        IFileReader fileReader)
    {
        _logger = logger;
        _fileReader = fileReader;
    }


    public async Task<List<OpdrachtItemDto>> GetOprachtItemsAsync()
    {
        var opdrachtItems = new List<OpdrachtItem>();
        var jsonData = await _fileReader.ReadWebroothPathFileAsync("opdrachten", "items.json");

        if (string.IsNullOrEmpty(jsonData))
        {
            return [];
        }

        opdrachtItems = JsonSerializer.Deserialize<List<OpdrachtItem>>(jsonData!, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        if (opdrachtItems == null)
        {
            _logger.LogWarning("Failed to deserialize opdrachtItems.");
            return [];
        }

        return opdrachtItems.Select(opdrachtItem => opdrachtItem.ToOpdrachtItem()).ToList();

    }
}
