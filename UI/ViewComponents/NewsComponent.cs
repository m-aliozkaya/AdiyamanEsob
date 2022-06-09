using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class NewsComponent : ViewComponent
{
    private readonly INewsService _newsService;

    public NewsComponent(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var news = await _newsService.GetHomeNews();
        return View(news.Data);
    }
}