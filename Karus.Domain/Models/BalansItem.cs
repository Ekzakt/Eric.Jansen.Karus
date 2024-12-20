namespace Karus.Domain.Models;

#nullable disable

public class BalansItem : BaseModel<Guid>
{

    public string Title { get; set; }

    public string CssClass { get; set; }

    public List<string> ShortTermValues { get; set; }

    public List<string> LongTermValues { get; set; }
}
