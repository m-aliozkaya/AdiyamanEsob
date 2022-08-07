using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IPresidentService
{
    Task<IDataResult<PresidentInfo>> GetByIdAsync(int id);

    Task<IResult> AddAsync(PresidentInfo president);

    Task<IResult> UpdateAsync(PresidentInfo president);
}