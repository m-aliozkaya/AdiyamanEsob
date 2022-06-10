using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Areas.Admin.Pages.Blog;

public class Index : PageModel
{
    private readonly IBlogService _blogService;
    private const int RecordsPerPage = 6;
    public PagingDto Paging { get; set; }
    
    [TempData]
    public string ErrorMessage { get; set; }
    
    public List<Entities.Entity.Blog> Blog { get; set; }
    
    public Index(IBlogService blogService)
    {
        _blogService = blogService;
    }
    public async Task<IActionResult> OnGet(int currentPage)
    {
        var result = await _blogService.GetAllByPage(RecordsPerPage, currentPage);
        Blog = result.Data.Blogs;

        Paging = new PagingDto
        {
            TotalRecords = result.Data.TotalRecors,
            CurrentPage = currentPage,
            RecordsPerPage = RecordsPerPage
        };

        return Page();
    }
}