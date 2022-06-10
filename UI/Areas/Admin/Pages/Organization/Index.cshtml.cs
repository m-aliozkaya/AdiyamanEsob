using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Organization;

public class Index : PageModel
{
    private readonly IOrganizationService _organizationService;

    public Index(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    public List<Entities.Entity.Organization> Organizations { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _organizationService.GetListAsync();
       Organizations = result.Data;
       return Page();
    }
}