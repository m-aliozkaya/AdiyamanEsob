using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Announcement;

public class Index : PageModel
{
    private readonly IAnnouncementService _announcementService;
    private const int RecordsPerPage = 8;
    public PagingDto Paging { get; set; }
    public List<Entities.Entity.Announcement> Announcements { get; set; }

    public Index(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }
    
    public async Task<IActionResult> OnGet(int currentPage)
    {
        var result = await _announcementService.GetAllByPage(RecordsPerPage, currentPage);
        Announcements = result.Data.Announcements;

        Paging = new PagingDto
        {
            TotalRecords = result.Data.TotalRecors,
            CurrentPage = currentPage,
            RecordsPerPage = RecordsPerPage
        };

        return Page();
    }
}