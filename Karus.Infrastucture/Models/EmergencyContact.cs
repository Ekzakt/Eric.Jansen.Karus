namespace Karus.Infrastucture.Models;

#nullable disable

public class EmergencyContact : BaseModel
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string ImageFilename { get; set; }
}
