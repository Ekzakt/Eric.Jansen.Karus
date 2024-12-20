namespace Karus.Application.Configuration;

public class KarusOptions
{
    public const string SectionName = "Karus";

    public List<string> AllowedIpAddresses { get; set; } = [];
}
