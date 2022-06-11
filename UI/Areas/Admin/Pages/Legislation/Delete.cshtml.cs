using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Legislation;

public class Delete : PageModel
{
    private readonly ILegislationService _legislationService;

    public Delete(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        await _legislationService.DeleteAsync(id);

        return Redirect("/admin/legislation");
    }
}