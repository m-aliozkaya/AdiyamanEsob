using System.ComponentModel;
using Business.Abstract;
using Core.Utilities.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.PresidentInfo
{
    public class Index : PageModel
    {
        private readonly IPresidentService _presidentService;

        public Index(IPresidentService presidentService)
        {
            _presidentService = presidentService;
        }

        [BindProperty] public Entities.Entity.PresidentInfo President { get; set; }

        [BindProperty]
        [DisplayName("Başkan Resmi")]
        public IFormFile UploadFile { get; set; }
        

        public async Task<IActionResult> OnGet()
        {
            var result = await _presidentService.GetByIdAsync(1);

            President = result.Data ?? new Entities.Entity.PresidentInfo();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var result= await ImageUploadHelper.UpdateImageAsync(UploadFile, "setting", President.Image);
            
            if (result.Success)
            {
                President.Image= result.Data;
            }
            
            await _presidentService.UpdateAsync(President);

            ViewData["Message"] = "Ayarlar başarıyla kaydedildi";
            return Page();
        }
    }
}