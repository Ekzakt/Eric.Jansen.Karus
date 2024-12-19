using Karus.Application.Enums;
using Karus.Infrastucture.JsonConverters;
using System.Text.Json.Serialization;

namespace Karus.Infrastucture.Models;

#nullable disable

public class SpotifyItem : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }


    [JsonConverter(typeof(SpotifyItemTypeJsonConverter))]
    public SpotifyItemType Type { get; set; }
}

