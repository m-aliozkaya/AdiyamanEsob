using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IPriceService
{
    Task<IDataResult<Price>> GetAsync(int id);
    Task<IDataResult<List<Price>>> GetListAsync();
    Task<IDataResult<List<Price>>> GetListAsync(bool? isCentre);
    Task<IDataResult<Price>> AddAsync(Price price);
    Task<IDataResult<Price>> UpdateAsync(Price price);
    Task<IDataResult<Price>> DeleteAsync(int id);
}