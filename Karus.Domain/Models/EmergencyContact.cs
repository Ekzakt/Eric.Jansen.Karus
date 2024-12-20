namespace Karus.Domain.Models;

#nullable disable

public class EmergencyContact : BaseModel<Guid>
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string ImageFilename { get; set; }
}
