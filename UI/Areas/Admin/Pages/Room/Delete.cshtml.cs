using Business.Abstract;
using Core.Utilities.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Room;

public class Delete : PageModel
{
    private readonly IRoomService _roomService;

    public Delete(IRoomService roomService)
    {
        _roomService = roomService;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        var room = await _roomService.GetAsync(id);
        await _roomService.DeleteAsync(id);
        return Redirect("/admin/room");
    }
}