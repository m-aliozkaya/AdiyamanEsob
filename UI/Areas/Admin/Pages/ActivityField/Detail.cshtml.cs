using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.ActivityField;

public class Detail : PageModel
{
    private readonly IActivityFieldService _activityFieldService;
    public Entities.Entity.ActivityField ActivityField { get; set; }

    public Detail(IActivityFieldService announcementService)
    {
        _activityFieldService = announcementService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _activityFieldService.GetBySeoUrlAsync(seoUrl);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Faaliyet Alanı detayı bulunamadı.";
            return Redirect("/admin/activityField");
        }

        ActivityField = result.Data;

        return Page();
    }
}