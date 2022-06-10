using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UI.Areas.Admin.Components.OrganizationComponent;

public class OrganizationComponent : ViewComponent
{
    private readonly IOrganizationService _organizationService;

    public OrganizationComponent(IOrganizationService organizationService)
    {
        _organizationService = organizationService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var news = await _organizationService.GetListAsync();
        return View(news.Data);
    }
}