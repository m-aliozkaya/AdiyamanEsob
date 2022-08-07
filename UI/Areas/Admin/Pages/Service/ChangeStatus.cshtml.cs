using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Service;

public class ChangeStatus : PageModel
{
    private readonly IServiceService _serviceService;

    public ChangeStatus(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _serviceService.GetAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _serviceService.UpdateAsync(result.Data);

        return Redirect("/admin/service");
    }
}