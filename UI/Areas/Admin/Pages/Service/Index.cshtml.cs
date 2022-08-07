using Business.Abstract;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Service;

public class Index : PageModel
{
    private readonly IServiceService _serviceService;

    public Index(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    public List<Entities.Entity.Service> Services { get; set; }
    
    public async Task OnGet()
    {
        var result = await _serviceService.GetListAsync();
        Services = result.Data;
    }
}