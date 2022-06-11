using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Organization;

public class Delete : PageModel
{
    private readonly IOrganizationService _organizationService;

    public Delete(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var organization = await _organizationService.GetAsync(id);
        await _organizationService.DeleteAsync(id);
        return Redirect("/admin/organization");
    }
}