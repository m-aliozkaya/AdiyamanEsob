using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Index : PageModel
{
    private readonly IOrganizationMemberService _organizationmemberService;

    public Index(IOrganizationMemberService organizationmemberService)
    {
        _organizationmemberService = organizationmemberService;
    }
    public List<Entities.Entity.OrganizationMember> OrganizationMembers { get; set; }
    public async Task<IActionResult> OnGet()
    {
       var result = await _organizationmemberService.GetListAsync();
       OrganizationMembers = result.Data;
       return Page();
    }
}