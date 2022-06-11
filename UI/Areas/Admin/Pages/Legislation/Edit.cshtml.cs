using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Legislation;

public class Edit : PageModel
{
    private readonly ILegislationService _legislationService;
    
    [BindProperty]
    public Entities.Entity.Legislation Legislation { get; set; }

    public Edit(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _legislationService.GetAsync(id.Value);
            Legislation = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Legislation = new Entities.Entity.Legislation();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Legislation is null)
        {
            return Redirect("/admin/legislation");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Legislation.Id > 0)
        {
            await _legislationService.UpdateAsync(Legislation);
        }
        else
        {
            await _legislationService.AddAsync(Legislation);
        }

        return Redirect("/admin/legislation");
    }
}