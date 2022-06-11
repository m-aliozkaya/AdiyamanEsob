using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class HeaderComponent : ViewComponent
{
    private readonly ISettingService _settingService;

    public HeaderComponent(ISettingService settingService)
    {
        _settingService = settingService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var setting = await _settingService.GetByIdAsync(1);
        return View(setting.Data);
    }
}