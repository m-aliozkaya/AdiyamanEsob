using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.ActivityField;

public class Index : PageModel
{
    private readonly IActivityFieldService _activityFieldService;

    public Entities.Entity.ActivityField ActivityField { get; set; }
    
    public Index(IActivityFieldService activityFieldService)
    {
        _activityFieldService = activityFieldService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _activityFieldService.GetBySeoUrlAsync(seoUrl);

        if (!result.Success)
        {
            return Redirect("/NotFound");
        }

        ActivityField = result.Data;
        return Page();
    }
}