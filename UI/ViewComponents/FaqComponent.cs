using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class FaqComponent : ViewComponent
{
    private readonly IFaqService _faqService;

    public FaqComponent(IFaqService newsService)
    {
        _faqService = newsService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var news = await _faqService.GetActiveFaq();
        return View(news.Data);
    }
}