using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.Areas.Admin.Pages.Setting;

public class OrganizationSchemaModel : PageModel
{
    [DisplayName("Organizasyon Şeması")]
    [BindProperty]
    public IFormFile UploadFile { get; set; }
    public string FilePath { get; set; }
    private readonly ISettingService _settingService;

    public OrganizationSchemaModel(ISettingService settingService)
    {
        _settingService = settingService;
    }
    public async Task<IActionResult> OnGet()
    {
        var result = await _settingService.GetByIdAsync(1);
        FilePath = result.Data?.OrganizationSchema;
        ViewData["ActionName"] = string.IsNullOrEmpty(FilePath) ? "Ekle" : "Düzenle";
        return Page();
    }
    public async Task<IActionResult> OnPost()
    {
        var result = await _settingService.GetByIdAsync(1);
        if (result.Data != null)
        {
            result.Data.OrganizationSchema = (await FileHelper.UpdateFileAsync(UploadFile, "setting", result.Data.OrganizationSchema)).Data;
            await _settingService.UpdateAsync(result.Data);
        }
        else
        {
            var setting = new Entities.Entity.Setting();
            setting.OrganizationSchema = (await FileHelper.UploadFileAsync(UploadFile, "setting")).Data;
            await _settingService.AddAsync(setting);
        }
        

        ViewData["Message"] = "Organizasyon �emas� ba�ar�yla kaydedildi";
        return Redirect("/admin");
    }
}
