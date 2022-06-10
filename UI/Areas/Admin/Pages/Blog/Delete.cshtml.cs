using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Blog;

public class Delete : PageModel
{
    private readonly IBlogService _blogService;

    public Delete(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public async Task<IActionResult> OnGetAsync(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        FileHelper.DeleteFile("blog/small", blog.Data.Image);
        FileHelper.DeleteFile("blog/medium", blog.Data.Image);

        await _blogService.DeleteAsync(id);

        return Redirect("/admin/blog");
    }
}