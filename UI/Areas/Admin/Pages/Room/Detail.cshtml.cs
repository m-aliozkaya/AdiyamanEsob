using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Room;

public class Detail : PageModel
{
    private readonly IRoomService _roomService;
    public Entities.Entity.Room Room { get; set; }
    
    public Detail(IRoomService roomService)
    {
        _roomService = roomService;
    }
    public async Task<IActionResult> OnGet(int id)
    {
        var result = await _roomService.GetAsync(id);

        if (result.Data is null)
        {
            return Redirect("/admin/room");
        }

        Room = result.Data;

        return Page();
    }
}