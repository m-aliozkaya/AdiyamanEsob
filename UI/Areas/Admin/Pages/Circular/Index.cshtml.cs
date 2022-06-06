using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Circular;

public class Index : PageModel
{
    private readonly ICircularService _circularService;
    public List<Entities.Entity.Circular> Circulars { get; set; }

    [DisplayName("Yıl")]
    public int YearFilter { get; set; } = DateTime.Now.Year;

    public Index(ICircularService circularService)
    {
        _circularService = circularService;
    }

    public async Task<IActionResult> OnGet(int? year)
    {
        var result = await _circularService.GetListAsync(year);
        Circulars = result.Data;
        
        if (year.HasValue)
        {
            ViewData["YearInfo"] = year.Value + " Yılına Ait ";
        }
        
        return Page();
    }
}