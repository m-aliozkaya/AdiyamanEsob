using Business.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.ActivityField;

public class Index : PageModel
{
    private readonly IActivityFieldService _activityFieldService;

    public Index(IActivityFieldService activityFieldService)
    {
        _activityFieldService = activityFieldService;
    }

    public List<Entities.Entity.ActivityField> ActivityFields { get; set; }
    
    public async Task OnGet()
    {
        var result = await _activityFieldService.GetListAsync();
        ActivityFields = result.Data;
    }
}