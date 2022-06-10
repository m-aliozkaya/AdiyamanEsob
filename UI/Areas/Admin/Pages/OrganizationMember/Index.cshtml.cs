using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Index : PageModel
{
    private readonly IOrganizationMemberService _organizationmemberService;
    private readonly IOrganizationService _organizationService;

    public Entities.Entity.Organization Organization { get; set; }
    
    public Index(IOrganizationMemberService organizationmemberService, IOrganizationService organizationService)
    {
        _organizationmemberService = organizationmemberService;
        _organizationService = organizationService;
    }

    public List<Entities.Entity.OrganizationMember> OrganizationMembers { get; set; }

    public async Task<IActionResult> OnGet(string seoUrl)
    {
        var organization = await _organizationService.GetAsync(seoUrl);

        Organization = organization.Data;
        
        var result = await _organizationmemberService.GetListAsync(organization.Data.Id);
        OrganizationMembers = result.Data;
        return Page();
    }
}