using Karus.Application.Enums;
using Karus.Infrastucture.JsonConverters;
using System.Text.Json.Serialization;

namespace Karus.Infrastucture.Models;

#nullable disable

public class Photo : BaseModel
{
    public string FileName { get; set; }

    [JsonConverter(typeof(PhotoTypeJsonConverter))]
    public PhotoType Type { get; set; }

    public string Description { get; set; }
}
