using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class RightBarComponent : ViewComponent
{
    private readonly ISettingService _settingService;

    public RightBarComponent(ISettingService settingService) 
    {
        _settingService = settingService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var videos = await _settingService.GetByIdAsync(1);
        
        return View(videos.Data);
    }
}