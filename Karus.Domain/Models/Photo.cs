using Karus.Domain.Enums;
using Karus.Domain.JsonConverters;
using System.Text.Json.Serialization;

namespace Karus.Domain.Models;

#nullable disable

public class Photo : BaseModel<Guid>
{
    public string FileName { get; set; }

    [JsonConverter(typeof(PhotoTypeJsonConverter))]
    public PhotoType Type { get; set; }

    public string Description { get; set; }
}
