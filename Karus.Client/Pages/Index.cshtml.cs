using Karus.Application.Contracts;
using Karus.Application.Dtos;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Karus.Client.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IOpdrachtItemsService _opdrachtItemsService;

    public List<OpdrachtItemDto>? OpdrachtItems { get; private set; } = null;

    public IndexModel(
        ILogger<IndexModel> logger, 
        IOpdrachtItemsService opdrachtItemsService)
    {
        _logger = logger;
        _opdrachtItemsService = opdrachtItemsService;
    }

    public async Task OnGetAsync()
    {
        var opdrachtItems = await _opdrachtItemsService.GetOprachtItemsAsync();
    }
}
