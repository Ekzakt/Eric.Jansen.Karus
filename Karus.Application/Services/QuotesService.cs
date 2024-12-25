using Karus.Application.Contracts;
using Karus.Application.Dtos;
using Karus.Application.Mappers;
using Karus.Domain.Models;

namespace Karus.Application.Services;

public class QuotesService : IGenericService<QuoteDto, Guid>
{
    private readonly IRepo<Quote, Guid> _repo;

    public QuotesService(IRepo<Quote, Guid> repo)
    {
        _repo = repo;
    }


    public async Task AddAsync(QuoteDto tdo)
    {
        await _repo.AddAsync(tdo.ToModel());
    }


    public async Task DeleteAsync(Guid id)
    {
        await _repo.DeleteAsync(id);
    }


    public async Task<List<QuoteDto>?> GetAllAsync()
    {
        var quotes = await _repo.GetAllAsync();
        var output = quotes?.Select(q => q.ToDto()).ToList();

        return output;
    }


    public async Task<QuoteDto?> GetByIdAsync(Guid id)
    {
        var quote = await _repo.GetByIdAsync(id);
        var output = quote?.ToDto();

        return output;
    }


    public Task UpdateAsync(QuoteDto tdo)
    {
        throw new NotImplementedException();
    }
}
