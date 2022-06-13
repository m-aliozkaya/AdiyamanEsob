using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IVideoService
{
    Task<IDataResult<Video>> GetAsync(int id);
    Task<IDataResult<List<Video>>> GetListAsync(int? count);
    Task<IDataResult<Video>> AddAsync(Video video);
    Task<IDataResult<Video>> UpdateAsync(Video video);
    Task<IDataResult<Video>> DeleteAsync(int id);
}