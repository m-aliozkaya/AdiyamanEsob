using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.AboutArticle;

public class Delete : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;

    public Delete(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        await _aboutArticleService.DeleteAsync(id);

        return Redirect("/admin/aboutArticle");
    }
}