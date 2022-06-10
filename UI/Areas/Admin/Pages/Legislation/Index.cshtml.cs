using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Legislation;

public class Index : PageModel
{
    private readonly ILegislationService _legislationService;
    public List<Entities.Entity.Legislation> Legislations { get; set; }
    
    public Index(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var result = await _legislationService.GetListAsync();
        Legislations = result.Data;
        return Page();
    }
}