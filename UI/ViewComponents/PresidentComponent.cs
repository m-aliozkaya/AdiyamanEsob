using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class PresidentComponent : ViewComponent
{
    private readonly IPresidentService _presidentService;

    public PresidentComponent(IPresidentService settingService) 
    {
        _presidentService = settingService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var president = await _presidentService.GetByIdAsync(1);
        
        return View(president.Data);
    }
}