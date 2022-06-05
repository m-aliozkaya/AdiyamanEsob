using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.AboutArticle;

public class Detail : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;
    public Entities.Entity.AboutArticle AboutArticle { get; set; }

    public Detail(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _aboutArticleService.GetAsync(id);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Hakkımızda yazısı bulunamadı.";
            return Redirect("/admin/aboutArticle");
        }

        AboutArticle = result.Data;

        return Page();
    }
}