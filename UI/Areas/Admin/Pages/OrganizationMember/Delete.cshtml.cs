using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Delete : PageModel
{
    private readonly IOrganizationMemberService _organizationmemberService;

    public Delete(IOrganizationMemberService organizationmemberService)
    {
        _organizationmemberService = organizationmemberService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var organizationmember = await _organizationmemberService.GetAsync(id);
        FileHelper.DeleteFile("organizationmember", organizationmember.Data.Image);
        await _organizationmemberService.DeleteAsync(id);
        return Redirect("/admin/organizationmember");
    }
}