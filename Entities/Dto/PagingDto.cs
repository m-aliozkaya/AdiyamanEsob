namespace Entities.Dto;

public class PagingDto
{
    public int TotalRecords { get; set; }
    public int CurrentPage { get; set; }
    public int RecordsPerPage { get; set; }
    public int TotalPages => (int)Math.Ceiling((decimal)TotalRecords / RecordsPerPage);

}