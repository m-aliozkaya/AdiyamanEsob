using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Organization;

public class Edit : PageModel
{
    private readonly IOrganizationService _organizationService;
    
    [BindProperty]
    public Entities.Entity.Organization Organization { get; set; }

    

    public Edit(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Organization = _organizationService.GetAsync(id.Value).Result.Data;
            
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Organization = new Entities.Entity.Organization();
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Organization is null)
        {
            return Redirect("/admin/organization");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (Organization.Id > 0)
        {
            await _organizationService.UpdateAsync(Organization);
        }
        else
        {
            await _organizationService.AddAsync(Organization);
        }

        return Redirect("/admin/organization");
    }
}