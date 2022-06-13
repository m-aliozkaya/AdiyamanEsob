using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class EnterpriseComponent : ViewComponent
{
    private readonly IAboutArticleService _aboutArticleService;
    private readonly IOrganizationService _organizationService;

    public EnterpriseComponent(IAboutArticleService aboutArticleService, IOrganizationService organizationService)
    {
        _aboutArticleService = aboutArticleService;
        _organizationService = organizationService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var organizations = await _organizationService.GetListAsync();
        var aboutArticles = await _aboutArticleService.GetActiveListAsync();
        
        var model = new EnterpriseComponentDto
        {
            Organization = organizations.Data,
            AboutArticles = aboutArticles.Data
        };
        
        return View(model);
    }
}