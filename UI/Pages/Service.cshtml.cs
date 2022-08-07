using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages;

public class Service : PageModel
{
    private readonly IServiceService _serviceService;
    public Entities.Entity.Service ServiceDetail { get; set; }

    public Service(IServiceService faqService)
    {
        _serviceService = faqService;
    }
    
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _serviceService.GetBySeoUrlAsync(seoUrl);

        if (!result.Success)
        {
            return Redirect("/NotFound");
        }

        ServiceDetail = result.Data;
        return Page();
    }
}