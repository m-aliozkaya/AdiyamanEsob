using Core.Utilities.Result.Abstract;
using Entities.Dto;
using Entities.Entity;

namespace Business.Abstract;

public interface INewsService
{
    Task<IDataResult<List<News>>> GetAllAsync();

    Task<IDataResult<NewsWithPageDetailDto>> GetAllByPage(int count, int? page = 1);
    
    Task<IDataResult<News>> GetByIdAsync(int id);
    Task<IDataResult<News>> GetBySeoUrlAsync(string seoUrl);

    Task<IDataResult<News>> AddAsync(News news);

    Task<IDataResult<News>> UpdateAsync(News news);

    Task<IDataResult<News>> DeleteAsync(int id);
}