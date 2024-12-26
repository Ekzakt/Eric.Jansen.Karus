using Karus.Application.Contracts;
using Karus.Data.AzureStorageTables.Entities;
using Karus.Data.AzureStorageTables.Mappers;
using Karus.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Karus.Data.AzureStorageTables.Repos;

public class QuotesRepo : BaseRepo<QuoteEntity, Guid>, IRepo<Quote, Guid>
{
    public QuotesRepo(ILogger<BaseRepo<QuoteEntity, Guid>> logger, string connectionString, string tableName)
        : base(logger, connectionString, tableName)
    {
    }


    public async Task AddAsync(Quote model)
    {
        var entity = model.ToEntity();
        await UpsertAsync(entity);
    }


    public async Task UpdateAsync(Quote model)
    {
        var entity = model.ToEntity();
        await UpdateAsync(entity);
    }


    public async Task DeleteAsync(Guid id)
    {
        await DeleteAsync("Quote", id);
    }


    public async Task<List<Quote>> GetAllAsync()
    {
        var quotes = await GetAllAsync("Quote");

        return quotes.Select(q => q.ToModel()).ToList();
    }


    public async Task<Quote?> GetByIdAsync(Guid id)
    {
        var quote = await GetByIdAsync("Quote", id);

        if (quote is not null)
        {
            return quote.ToModel();
        }

        return null;
    }
}
