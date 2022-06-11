using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Setting
{
    public class Index : PageModel
    {
        
        private readonly ISettingService _settingService;

        public Index(ISettingService settingService)
        {
            _settingService = settingService;
        }
        [BindProperty]
        public Entities.Entity.Setting Setting { get; set; }
        public async Task<IActionResult> OnGet()
        {
            var result = await _settingService.GetByIdAsync(1);
            
            Setting = result.Data??new Entities.Entity.Setting();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(Setting.Id>0)
                await _settingService.UpdateAsync(Setting);
            else
                await _settingService.AddAsync(Setting);

            ViewData["Message"] = "Ayarlar başarıyla kaydedildi";
            return Page();
        }
    }
}
