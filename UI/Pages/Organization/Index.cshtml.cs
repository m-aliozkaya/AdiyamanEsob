using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Organization
{
    public class IndexModel : PageModel
    {
        private readonly IOrganizationService _organizationService;
        private readonly IOrganizationMemberService _organizationMemberService;

        public List<OrganizationMember> OrganizationMembers { get; set; }
        public Entities.Entity.Organization Organization { get; set; }
        public IndexModel(IOrganizationService organizationService, IOrganizationMemberService organizationMemberService)
        {
            _organizationService = organizationService;
            _organizationMemberService = organizationMemberService;
        }

        public async Task<IActionResult> OnGetAsync(string seoUrl)
        {
            var organization = await _organizationService.GetAsync(seoUrl);

            Organization = organization.Data;

            var organizationMember = await _organizationMemberService.GetListAsync(Organization.Id);
            OrganizationMembers = organizationMember.Data;
         
            return Page();
        }
    }
}
