using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Legislation;

public class LegislationSingle : PageModel
{
    private readonly ILegislationService _legislationService;
    
    public Entities.Entity.Legislation Legislation { get; set; }
    
    public LegislationSingle(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    public async Task<IActionResult> OnGetAsync(string seoUrl)
    {
        var result = await _legislationService.GetBySeoUrl(seoUrl);
        Legislation = result.Data;
        return Page();
    }
}