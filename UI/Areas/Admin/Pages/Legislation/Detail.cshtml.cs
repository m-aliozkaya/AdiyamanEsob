using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Legislation;

public class Detail : PageModel
{
    private readonly ILegislationService _legislationService;
    public Entities.Entity.Legislation Legislation { get; set; }

    public Detail(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _legislationService.GetAsync(id);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Mevzuat bulunamadı.";
            return Redirect("/admin/legislation");
        }

        Legislation = result.Data;

        return Page();
    }
}