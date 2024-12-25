namespace Karus.Application.Dtos;

#nullable disable

public abstract class BaseDto<TIdType>
{
    public TIdType Id { get; set; }
}
