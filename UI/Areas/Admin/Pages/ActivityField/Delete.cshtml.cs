using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.ActivityField;

public class Delete : PageModel
{
    private readonly IActivityFieldService _activityFieldService;

    public Delete(IActivityFieldService activityFieldService)
    {
        _activityFieldService = activityFieldService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        await _activityFieldService.DeleteAsync(id);
        return Redirect("/admin/activityField");
    }
}