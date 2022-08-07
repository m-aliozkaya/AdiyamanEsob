using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.ActivityField;

public class ChangeStatus : PageModel
{
    private readonly IActivityFieldService _activityFieldService;

    public ChangeStatus(IActivityFieldService activityFieldService)
    {
        _activityFieldService = activityFieldService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _activityFieldService.GetAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _activityFieldService.UpdateAsync(result.Data);

        return Redirect("/admin/activityField");
    }
}