using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.AboutArticle;

public class Edit : PageModel
{
    private readonly IAboutArticleService _aboutArticleService;
    
    [BindProperty]
    public Entities.Entity.AboutArticle AboutArticle { get; set; }

    public Edit(IAboutArticleService aboutArticleService)
    {
        _aboutArticleService = aboutArticleService;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        if (id.HasValue)
        {
            var result = await _aboutArticleService.GetAsync(id.Value);
            AboutArticle = result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            AboutArticle = new Entities.Entity.AboutArticle();
            ViewData["ActionName"] = "Ekle";
        }
        
        if (AboutArticle is null)
        {
            return Redirect("/admin/aboutArticle");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (AboutArticle.Id > 0)
        {
            await _aboutArticleService.UpdateAsync(AboutArticle);
        }
        else
        {
            await _aboutArticleService.AddAsync(AboutArticle);
        }

        return Redirect("/admin/aboutArticle");
    }
}