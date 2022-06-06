using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Room;

public class Index : PageModel
{
    private readonly IRoomService _roomService;

    public Index(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public List<Entities.Entity.Room> Rooms { get; set; }

    public async Task<IActionResult> OnGet(bool? isCentre)
    {
        if (isCentre.HasValue)
        {
            if (isCentre.Value)
            {
                ViewData["RoomType"] = "Merkez";
            }
            else
            {
                ViewData["RoomType"] = "Şube";
            }
        }

        var result = await _roomService.GetListAsync(isCentre);
        Rooms = result.Data;
        return Page();
    }
}