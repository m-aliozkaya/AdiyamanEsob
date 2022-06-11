using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class LastBlogComponent : ViewComponent
{
    private readonly IBlogService _blogService;

    public LastBlogComponent(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var blogs = await _blogService.GetLatestBlogs();
        
        return View(blogs.Data);
    }
}