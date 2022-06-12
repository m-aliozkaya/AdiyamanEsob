using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Legislation;

public class Index : PageModel
{
    private readonly ILegislationService _legislationService;
    public List<Entities.Entity.Legislation> Legislation { get; set; }

    public Index(ILegislationService legislationService)
    {
        _legislationService = legislationService;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        var result = await _legislationService.GetListAsync();
        Legislation = result.Data;

        return Page();
    }
}