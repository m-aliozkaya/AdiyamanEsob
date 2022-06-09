using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Detail : PageModel
{
    private readonly IOrganizationMemberService _organizationmemberService;

    public Entities.Entity.OrganizationMember OrganizationMember { get; set; }
    
    public Detail(IOrganizationMemberService organizationmemberService)
    {
        _organizationmemberService = organizationmemberService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _organizationmemberService.GetAsync(id);

        if (result.Data == null)
        {
            return Redirect("/admin/organizationmember");
        }

        OrganizationMember = result.Data;

        return Page();
    }
}