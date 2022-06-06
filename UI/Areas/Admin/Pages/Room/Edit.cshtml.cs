using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Room;

public class Edit : PageModel
{
    private readonly IRoomService _roomService;
    
    [BindProperty]
    public Entities.Entity.Room Room { get; set; }
    
    public Edit(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            Room = _roomService.GetAsync(id.Value).Result.Data;
            ViewData["ActionName"] = "Düzenle";
        }
        else
        {
            Room =new Entities.Entity.Room()
            {
                IsCentre = false
            };
            
            ViewData["ActionName"] = "Ekle";
        }
        
        if (Room is null)
        {
            return Redirect("/admin/room");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (Room.Id > 0)
        {
            await _roomService.UpdateAsync(Room);
        }
        else
        {
            await _roomService.AddAsync(Room);
        }

        return Redirect("/admin/room");
    }
}