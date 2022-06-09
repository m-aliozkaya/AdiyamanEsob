using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Blog;

public class Detail : PageModel
{
    private readonly IBlogService _blogService;
    public Entities.Entity.Blog Blog { get; set; }

    public Detail(IBlogService blogService)
    {
        _blogService = blogService;
    }
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _blogService.GetBySeoUrlAsync(seoUrl);

        if (result.Data == null)
        {
            TempData["ErrorMessage"] = "Blog detayı bulunamadı.";
            return Redirect("/admin/blog");
        }

        Blog = result.Data;

        return Page();
    }
}