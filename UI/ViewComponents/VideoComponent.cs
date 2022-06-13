using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class VideoComponent : ViewComponent
{
    private readonly IVideoService _videoService;

    public VideoComponent(IVideoService videoService)
    {
        _videoService = videoService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var videos = await _videoService.GetListAsync(3);
        
        return View(videos.Data);
    }
}