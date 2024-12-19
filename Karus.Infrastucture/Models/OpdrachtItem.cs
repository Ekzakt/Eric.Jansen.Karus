namespace Karus.Infrastucture.Models;

#nullable disable

public class OpdrachtItem : BaseModel
{
    public string Name { get; set; }

    public string CardImageUri { get; set; }

    public string NavigationUri { get; set; }

    public string Description { get; set; }
}
