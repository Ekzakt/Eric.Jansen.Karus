namespace Karus.Domain.Models;

public class Quote : BaseModel<Guid>
{
    public string Text { get; set; } = string.Empty;

    public string? Author { get; set; }

    public int? QuoteYear { get; set; }

    public string? Location { get; set; }

    public string? Category { get; set; }
}
