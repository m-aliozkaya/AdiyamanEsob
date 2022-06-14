using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Blog;

public class NewsSingle : PageModel
{
    private readonly IBlogService _blogService;
    public Entities.Entity.Blog Blog { get; set; }

    public NewsSingle(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var result = await _blogService.GetBySeoUrlAsync(seoUrl);

        if (!result.Success)
        {
           return Redirect("/NotFound");
        }

        Blog = result.Data;
        return Page();
    }
}