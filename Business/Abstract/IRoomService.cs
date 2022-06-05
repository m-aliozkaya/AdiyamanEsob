using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IRoomService
{
    Task<IDataResult<Room>> GetAsync(int id);
    Task<IDataResult<List<Room>>> GetListAsync();
    Task<IDataResult<Room>> AddAsync(Room room);
    Task<IDataResult<Room>> UpdateAsync(Room room);
    Task<IDataResult<Room>> DeleteAsync(int id);
}