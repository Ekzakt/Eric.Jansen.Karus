namespace Karus.Application.Configuration;

#nullable disable

public class KarusOptions
{
    public const string SectionName = "Karus";

    public List<string> AllowedIpAddresses { get; init; } = [];
}
