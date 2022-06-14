using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.AboutArticle;

public class AboutArticleSingle : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;
    public Entities.Entity.AboutArticle AboutArticle { get; set; }

    public AboutArticleSingle(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _aboutArticleService.GetBySeoUrl(seoUrl);

        if (!result.Success)
        {
           return Redirect("/NotFound");
        }

        AboutArticle = result.Data;
        return Page();
    }
}