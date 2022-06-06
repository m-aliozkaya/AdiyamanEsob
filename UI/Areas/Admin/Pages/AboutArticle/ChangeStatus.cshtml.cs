using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.AboutArticle;

public class ChangeStatus : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;

    public ChangeStatus(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _aboutArticleService.GetAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _aboutArticleService.UpdateAsync(result.Data);

        return Redirect("/admin/aboutArticle");
    }
}