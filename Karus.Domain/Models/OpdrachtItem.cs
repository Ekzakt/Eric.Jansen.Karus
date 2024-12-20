namespace Karus.Domain.Models;

#nullable disable

public class OpdrachtItem : BaseModel<Guid>
{
    public string Name { get; set; }

    public string CardImageFilename { get; set; }

    public string NavigationUri { get; set; }

    public string Description { get; set; }
}
