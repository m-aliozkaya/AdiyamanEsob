using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.News;

public class Detail : PageModel
{
    private readonly INewsService _newsService;
    public Entities.Entity.News News { get; set; }

    public Detail(INewsService newsService)
    {
        _newsService = newsService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _newsService.GetBySeoUrlAsync(seoUrl);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Haber detayı bulunamadı.";
            return Redirect("/admin/news");
        }

        News = result.Data;

        return Page();
    }
}