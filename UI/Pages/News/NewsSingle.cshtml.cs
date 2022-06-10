using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.News;

public class NewsSingle : PageModel
{
    private readonly INewsService _newsService;
    public Entities.Entity.News News { get; set; }

    public NewsSingle(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _newsService.GetBySeoUrlAsync(seoUrl);

        if (!result.Success)
        {
            return RedirectToPage("./NotFound");
        }

        News = result.Data;
        return Page();
    }
}