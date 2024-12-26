namespace Karus.Domain.Models;

#nullable disable

public abstract class BaseModel<TId>
{
    public TId Id { get; set; }

    public int SortNumber { get; set; } = 100;

    public bool IsInVisible { get; set; } = false;

    public DateTime Added { get; set; } = DateTime.UtcNow;

    public DateTime? Modified { get; set; }
}
