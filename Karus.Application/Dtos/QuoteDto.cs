namespace Karus.Application.Dtos;

public class QuoteDto : BaseDto<Guid>
{
    public string Text { get; set; } = string.Empty;

    public string? Author { get; set; }

    public DateOnly? QuoteDate { get; set; }

    public int? QuoteYear { get; set; }

    public string? Location { get; set; }

    public string? Category { get; set; }
}
