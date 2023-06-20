using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MeuCondominio.Pages.Error
{
    public class ErrorModel : PageModel
    {
        public void OnGet()
        {
            ViewData["ErrorMessage"] = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error.Message;
        }
    }
}
