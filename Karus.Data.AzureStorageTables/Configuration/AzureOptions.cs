namespace Karus.Data.AzureStorageTables.Configuration;

#nullable disable

public class AzureOptions
{
    public const string SectionName = "Azure";

    public AzureTableStorageOptions TableStorage { get; set; }
}
