using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Edit : PageModel
{
    private readonly IOrganizationMemberService _organizationMemberService;
    private readonly IOrganizationService _organizationService;
    
    [BindProperty]
    public Entities.Entity.OrganizationMember OrganizationMember { get; set; }
    
    [BindProperty]
    public List<Entities.Entity.Organization> Organizations { get; set; }

    [DisplayName("Dosya")]
    [Required]
    [BindProperty]
    public IFormFile UploadFile { get; set; }

    public Edit(IOrganizationMemberService organizationMemberService,IOrganizationService organizationService)
    {
        _organizationMemberService = organizationMemberService;
        _organizationService = organizationService;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        var result = (await _organizationService.GetListAsync());
        Organizations = result.Data;
       
        if (id.HasValue)
        {
            OrganizationMember = _organizationMemberService.GetAsync(id.Value).Result.Data;
            
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            OrganizationMember = new Entities.Entity.OrganizationMember
            {
                Organization = new Entities.Entity.Organization()
            };
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (OrganizationMember is null)
        {
            return Redirect("/admin/organizationmember");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        
        if (OrganizationMember.Id > 0)
        {
            var result = await FileHelper.UpdateFileAsync(UploadFile, "organizationmember", OrganizationMember.Image);
            OrganizationMember.Image= result.Data;
            await _organizationMemberService.UpdateAsync(OrganizationMember);
        }
        else
        {
            var result=await FileHelper.UploadFileAsync(UploadFile, "organizationmember");
            OrganizationMember.Image = result.Data;
            await _organizationMemberService.AddAsync(OrganizationMember);
        }

        return Redirect("/admin/organizationmember");
    }
}