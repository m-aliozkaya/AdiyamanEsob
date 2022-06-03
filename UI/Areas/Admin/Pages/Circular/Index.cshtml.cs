using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Circular;

public class Index : PageModel
{
    private readonly ICircularService _circularService;

    public Index(ICircularService circularService)
    {
        _circularService = circularService;
    }
    public List<Entities.Entity.Circular> Circulars { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _circularService.GetListAsync();
       Circulars = result.Data;
       return Page();
    }
}