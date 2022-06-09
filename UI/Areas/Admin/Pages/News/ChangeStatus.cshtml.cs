using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.News;

public class ChangeStatus : PageModel
{
    private readonly INewsService _newsService;

    public ChangeStatus(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _newsService.GetByIdAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _newsService.UpdateAsync(result.Data);

        return Redirect("/admin/news");
    }
}