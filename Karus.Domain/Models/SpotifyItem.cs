using Karus.Domain.Enums;
using Karus.Domain.JsonConverters;
using System.Text.Json.Serialization;

namespace Karus.Domain.Models;

#nullable disable

public class SpotifyItem : BaseModel<SpotifyItem>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Uri { get; set; }


    [JsonConverter(typeof(SpotifyItemTypeJsonConverter))]
    public SpotifyItemType Type { get; set; }
}

