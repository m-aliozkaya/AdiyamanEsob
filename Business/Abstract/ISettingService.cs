using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface ISettingService
{
    Task<IDataResult<List<Setting>>> GetAllAsync();

    Task<IDataResult<Setting>> GetByIdAsync(int id);

    Task<IResult> AddAsync(Setting setting);

    Task<IResult> UpdateAsync(Setting setting);

    Task<IResult> DeleteAsync(int id);
}