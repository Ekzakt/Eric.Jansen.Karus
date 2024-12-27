using Karus.Application.Dtos;

namespace Karus.Application.Contracts;

public interface IGenericService<TDto, TIdType>
    where TDto : BaseDto<TIdType>
{
    Task AddAsync(TDto tdo);

    Task UpdateAsync(TDto tdo);

    Task DeleteAsync(TIdType id);

    Task<List<TDto>?> GetAllAsync();
    
    Task<TDto?> GetByIdAsync(TIdType? id);
}
