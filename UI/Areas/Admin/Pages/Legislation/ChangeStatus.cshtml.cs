using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Legislation;

public class ChangeStatus : PageModel
{
    private readonly ILegislationService _legislationService;

    public ChangeStatus(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _legislationService.GetAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _legislationService.UpdateAsync(result.Data);

        return Redirect("/admin/legislation");
    }
}