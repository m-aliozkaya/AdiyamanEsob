using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Faq;

public class ChangeStatus : PageModel
{
    private readonly IFaqService _faqService;

    public ChangeStatus(IFaqService faqService)
    {
        _faqService = faqService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _faqService.GetAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _faqService.UpdateAsync(result.Data);

        return Redirect("/admin/faq");
    }
}