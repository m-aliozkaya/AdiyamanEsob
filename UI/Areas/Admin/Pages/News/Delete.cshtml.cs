using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.News;

public class Delete : PageModel
{
    private readonly INewsService _newsService;

    public Delete(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var news = await _newsService.GetByIdAsync(id);
        FileHelper.DeleteFile("news/small", news.Data.Image);
        FileHelper.DeleteFile("news/medium", news.Data.Image);

        await _newsService.DeleteAsync(id);

        return Redirect("/admin/news");
    }
}