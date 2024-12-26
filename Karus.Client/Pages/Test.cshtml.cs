using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Karus.Client.Pages
{
    public class TestModel : PageModel
    {
        public IActionResult OnGetQuote(Guid id)
        {
            return new JsonResult(new { id, message = "Handler invoked successfully" });
        }

        public IActionResult OnGetAsync()
        {
            return Page();
        }
    }
}
