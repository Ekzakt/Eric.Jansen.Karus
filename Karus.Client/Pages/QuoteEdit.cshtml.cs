using Karus.Application.Contracts;
using Karus.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Karus.Client.Pages;

public class QuotesPageModel : PageModel
{
    private readonly IGenericService<QuoteDto, Guid> _quoteService;

    [BindProperty]
    public QuoteDto Quote { get; set; } = new();

    public IEnumerable<QuoteDto>? Quotes { get; set; } = null;

    public QuotesPageModel(IGenericService<QuoteDto, Guid> quoteService)
    {
        _quoteService = quoteService;
    }

    public async Task OnGetAsync()
    {
        Quotes = await _quoteService.GetAllAsync();
    }


    public async Task<IActionResult> OnPostUpsertAsync(QuoteDto quote)
    {
        var quoteDto = new QuoteDto
        {
            Id = quote.Id,
            Text = quote.Text,
            Author = quote.Author,
            Category = quote.Location
        };

        await _quoteService.AddAsync(quoteDto);

        return RedirectToPage();
    }


    public async Task<IActionResult> OnPostDeleteAsync(Guid id)
    {
        await _quoteService.DeleteAsync(id);

        return RedirectToPage();
    }
}