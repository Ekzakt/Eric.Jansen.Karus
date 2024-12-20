namespace Karus.Domain.Models;

#nullable disable

public class HaltItem : BaseModel<Guid>
{
    public string Name { get; set; }

    public string ImageFilename { get; set; }

    public string Description { get; set; }
}
