using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Faq;

public class Delete : PageModel
{
    private readonly IFaqService _faqService;

    public Delete(IFaqService faqService)
    {
        _faqService = faqService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var faq = await _faqService.GetAsync(id);
        await _faqService.DeleteAsync(id);
        return Redirect("/admin/faq");
    }
}