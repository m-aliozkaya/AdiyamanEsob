using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Service;

public class Delete : PageModel
{
    private readonly IServiceService _serviceService;

    public Delete(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        await _serviceService.DeleteAsync(id);
        return Redirect("/admin/service");
    }
}