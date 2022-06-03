using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface ICircularService
{
    Task<IDataResult<Circular>> GetAsync(int id);
    Task<IDataResult<List<Circular>>> GetListAsync();
    Task<IDataResult<Circular>> AddAsync(Circular circular);
    Task<IDataResult<Circular>> UpdateAsync(Circular circular);
    Task<IDataResult<Circular>> DeleteAsync(int id);
}