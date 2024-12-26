namespace Karus.Data.AzureStorageTables.Entities;

#nullable disable

public class QuoteEntity : BaseEntity
{
    public string Text { get; set; }

    public string Author { get; set; }

    public int? QuoteYear { get; set; }

    public string Location { get; set; }

    public string Category { get; set; }
}
