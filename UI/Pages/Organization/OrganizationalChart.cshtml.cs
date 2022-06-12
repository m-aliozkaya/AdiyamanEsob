using Business.Abstract;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Organization
{
    public class OrganizationalChartModel : PageModel
    {
        private readonly ISettingService _settingService;

        public Setting Setting { get; set; }
        public OrganizationalChartModel(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var result = await _settingService.GetByIdAsync(1);
            Setting = result.Data;

            return Page();
        }
    }
}
