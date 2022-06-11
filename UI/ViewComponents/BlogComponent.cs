using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class BlogComponent : ViewComponent
{
    private readonly IBlogService _blogService;

    public BlogComponent(IBlogService blogService)
    {
        _blogService = blogService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var blogs = await _blogService.GetHomeBlogs();
        
        return View(blogs.Data);
    }
}