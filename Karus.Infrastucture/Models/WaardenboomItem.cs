namespace Karus.Infrastucture.Models;

#nullable disable

public class WaardenboomItem : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Content { get; set; }

    public int X { get; set; } = 0;

    public int Y { get; set; } = 0;
}
