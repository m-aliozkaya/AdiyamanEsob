using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.ViewComponents;

public class HeaderComponent : ViewComponent
{
    private readonly ISettingService _settingService;
    private readonly ICircularService _circularService;
    private readonly IActivityFieldService _activityFieldService;
    private readonly IServiceService _serviceService;

    public HeaderComponent(ISettingService settingService, ICircularService circularService
        , IActivityFieldService activityFieldService, IServiceService serviceService)
    {
        _settingService = settingService;
        _circularService = circularService;
        _activityFieldService = activityFieldService;
        _serviceService = serviceService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var setting = await _settingService.GetByIdAsync(1);
        var circulars = await _circularService.GetYearsAsync();
        var activityFields = await _activityFieldService.GetHome();
        var services = await _serviceService.GetHome();
        
        return View(new HeaderViewModel
        {
            CircularYears = circulars.Data,
            Setting = setting.Data,
            ActivityFields = activityFields.Data,
            Services = services.Data
        });
    }
}