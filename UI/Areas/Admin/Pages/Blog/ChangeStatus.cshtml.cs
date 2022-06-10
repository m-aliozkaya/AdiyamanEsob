using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Blog;

public class ChangeStatus : PageModel
{
    private readonly IBlogService _blogService;

    public ChangeStatus(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var result = await _blogService.GetByIdAsync(id);
        result.Data.IsActive = !result.Data.IsActive;
        await _blogService.UpdateAsync(result.Data);

        return Redirect("/admin/blog");
    }
}