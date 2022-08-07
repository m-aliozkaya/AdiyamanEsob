using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Faq;

public class Index : PageModel
{
    private readonly IFaqService _faqService;
    public Entities.Entity.Faq Faq { get; set; }

    public Index(IFaqService faqService)
    {
        _faqService = faqService;
    }
    
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _faqService.GetBySeoUrl(seoUrl);

        if (!result.Success)
        {
            return Redirect("/NotFound");
        }

        Faq = result.Data;
        return Page();
    }
}