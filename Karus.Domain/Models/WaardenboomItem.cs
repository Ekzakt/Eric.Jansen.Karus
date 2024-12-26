namespace Karus.Domain.Models;

#nullable disable

public class WaardenboomItem : BaseModel<Guid>
{
    public string Name { get; set; }

    public string Content { get; set; }

    public int X { get; set; } = 0;

    public int Y { get; set; } = 0;
}
