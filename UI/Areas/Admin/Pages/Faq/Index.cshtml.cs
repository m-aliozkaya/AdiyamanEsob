using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Faq;

public class Index : PageModel
{
    private readonly IFaqService _faqService;

    public Index(IFaqService faqService)
    {
        _faqService = faqService;
    }
    public List<Entities.Entity.Faq> Faqs { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _faqService.GetListAsync();
       Faqs = result.Data;
       return Page();
    }
}