using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class AnnouncementComponent : ViewComponent
{
    private readonly IAnnouncementService _announcementService;

    public AnnouncementComponent(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var news = await _announcementService.GetHomeAnnouncements();
        return View(news.Data);
    }
}