using Karus.Data.AzureStorageTables.Entities;
using Karus.Domain.Models;

namespace Karus.Data.AzureStorageTables.Mappers;

public static class EntityMapperExtensions
{
    public static QuoteEntity ToEntity(this Quote model)
    {
        return new QuoteEntity
        {
            PartitionKey = "Quote",
            RowKey = model.Id == Guid.Empty ? Guid.NewGuid().ToString() : model.Id.ToString(),
            Author = model.Author,
            QuoteYear = model.QuoteYear,
            Text = model.Text,
            Location = model.Location,
            Category = model.Category,
            Added = DateTime.UtcNow
        };
    }

    public static Quote ToModel(this QuoteEntity entity)
    {
        return new Quote
        {
            Id = Guid.Parse(entity.RowKey),
            Text = entity.Text,
            Author = entity.Author,
            QuoteYear = entity.QuoteYear,
            Location = entity.Location,
            Category = entity.Category
        };
    }
}