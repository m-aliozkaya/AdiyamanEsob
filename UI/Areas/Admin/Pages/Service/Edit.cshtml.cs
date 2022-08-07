using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Service;

public class Edit : PageModel
{
    private readonly IServiceService _serviceService;
    
    [BindProperty]
    public Entities.Entity.Service Service { get; set; }
    
    public Edit(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _serviceService.GetAsync(id.Value);
            Service = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Service = new Entities.Entity.Service();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Service is null)
        {
            return Redirect("/admin/service");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Service.Id > 0)
        {
            await _serviceService.UpdateAsync(Service);
        }
        else
        {
            await _serviceService.AddAsync(Service);
        }

        return Redirect("/admin/service");
    }
}