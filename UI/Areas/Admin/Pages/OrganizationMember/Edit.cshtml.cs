using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Areas.Admin.Pages.OrganizationMember;

public class Edit : PageModel
{
    private readonly IOrganizationMemberService _organizationMemberService;
    private readonly IOrganizationService _organizationService;

    [BindProperty] public Entities.Entity.OrganizationMember OrganizationMember { get; set; }

    [BindProperty] public List<Entities.Entity.Organization> Organizations { get; set; }

    [BindProperty(SupportsGet = true)] public int? OrganizationId { get; set; }
    public SelectList Options { get; set; }

    [DisplayName("Dosya")] [BindProperty] public IFormFile UploadFile { get; set; }

    public Edit(IOrganizationMemberService organizationMemberService, IOrganizationService organizationService)
    {
        _organizationMemberService = organizationMemberService;
        _organizationService = organizationService;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        var result = (await _organizationService.GetListAsync());
        Organizations = result.Data;

        Options = new SelectList(Organizations, nameof(Entities.Entity.Organization.Id),
            nameof(Entities.Entity.Organization.Name));

        if (id.HasValue)
        {
            OrganizationMember = _organizationMemberService.GetAsync(id.Value).Result.Data;
            var organization = await _organizationService.GetAsync(OrganizationMember.OrganizationId);
            ViewData["ActionName"] = "Düzenle";
            ViewData["ReturnUrl"] = organization.Data.SeoUrl;
        }
        else
        {
            OrganizationMember = new Entities.Entity.OrganizationMember();

            if (OrganizationId.HasValue)
            {
                OrganizationMember.OrganizationId = OrganizationId.Value;
                var organization = await _organizationService.GetAsync(OrganizationId.Value);
            
                ViewData["ReturnUrl"] = organization.Data.SeoUrl;
            }

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
            var result =
                await ImageUploadHelper.UpdateImageAsync(UploadFile, "organizationmember", OrganizationMember.Image);

            if (result.Success)
            {
                OrganizationMember.Image = result.Data;
            }

            await _organizationMemberService.UpdateAsync(OrganizationMember);
        }
        else
        {
            var result = await FileHelper.UploadFileAsync(UploadFile, "organizationmember");
            OrganizationMember.Image = result.Data;
            await _organizationMemberService.AddAsync(OrganizationMember);
        }

        var organization = await _organizationService.GetAsync(OrganizationMember.OrganizationId);
        return Redirect("/admin/organizationmember/" + organization.Data.SeoUrl);
    }
}