using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.AboutArticle;

public class Index : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;
    public List<Entities.Entity.AboutArticle> AboutArticles { get; set; }
    
    public Index(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var result = await _aboutArticleService.GetListAsync();
        AboutArticles = result.Data;
        return Page();
    }
}