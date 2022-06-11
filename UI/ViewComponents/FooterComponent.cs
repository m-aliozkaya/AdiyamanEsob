using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents;

public class FooterComponent : ViewComponent
{
    private readonly IAboutArticleService _aboutArticleService;
    private readonly IOrganizationService _organizationService;

    public FooterComponent(IAboutArticleService aboutArticleService, IOrganizationService organizationService)
    {
        _aboutArticleService = aboutArticleService;
        _organizationService = organizationService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var organizations = await _organizationService.GetListAsync();
        var aboutArticles = await _aboutArticleService.GetListAsync();
        
        var model = new EnterpriseComponentDto
        {
            Organization = organizations.Data,
            AboutArticles = aboutArticles.Data
        };
        
        return View(model);
    }
}