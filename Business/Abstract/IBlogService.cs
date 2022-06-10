using Core.Utilities.Result.Abstract;
using Entities.Dto;
using Entities.Entity;

namespace Business.Abstract;

public interface IBlogService
{
    Task<IDataResult<List<Blog>>> GetAllAsync();

    Task<IDataResult<BlogWithPageDetailDto>> GetAllByPage(int count, int? page = 1);
    
    Task<IDataResult<Blog>> GetByIdAsync(int id);
    Task<IDataResult<Blog>> GetBySeoUrlAsync(string seoUrl);

    Task<IDataResult<Blog>> AddAsync(Blog blog);

    Task<IDataResult<Blog>> UpdateAsync(Blog blog);

    Task<IDataResult<Blog>> DeleteAsync(int id);

    Task<IDataResult<List<Blog>>> GetHomeBlog();
}