using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Faq;

public class Detail : PageModel
{
    private readonly IFaqService _faqService;

    public Entities.Entity.Faq Faq { get; set; }
    
    public Detail(IFaqService faqService)
    {
        _faqService = faqService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _faqService.GetAsync(id);

        if (result.Data == null)
        {
            return Redirect("/admin/faq");
        }

        Faq = result.Data;

        return Page();
    }
}