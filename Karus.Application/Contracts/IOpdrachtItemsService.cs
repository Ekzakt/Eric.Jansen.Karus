using Karus.Application.Dtos;

namespace Karus.Application.Contracts;

public interface IOpdrachtItemsService
{
    Task<List<OpdrachtItemDto>> GetOprachtItemsAsync();
}
