using Karus.Domain.Models;

namespace Karus.Application.Contracts;

public interface IRepo<TModel, TIdType> 
    where TModel : BaseModel<TIdType>
{
    Task AddAsync(TModel model);

    Task UpdateAsync(TModel model);

    Task DeleteAsync(TIdType id);

    Task<List<TModel>> GetAllAsync();

    Task<TModel?> GetByIdAsync(TIdType id);


}
