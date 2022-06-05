using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class RoomManager : IRoomService
{
    private readonly IRoomDal _roomDal;

    public RoomManager(IRoomDal roomDal)
    {
        _roomDal = roomDal;
    }

    public async Task<IDataResult<Room>> GetAsync(int id)
    {
        var result = await _roomDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Room>(result);
        }

        return new ErrorDataResult<Room>();
    }
    
    public async Task<IDataResult<List<Room>>> GetListAsync()
    {
        var result = await _roomDal.GetAllAsync();
        
        return new SuccessDataResult<List<Room>>(result);
    }

    public async Task<IDataResult<List<Room>>> GetListAsync(bool? isCentre)
    {
        List<Room> result;
        if (!isCentre.HasValue)
        {
            result = await _roomDal.GetAllAsync();
        }
        else
        {
            result = result = await _roomDal.GetAllAsync(x => x.IsCentre == isCentre);
        }

        return new SuccessDataResult<List<Room>>(result);
    }

    public async Task<IDataResult<Room>> AddAsync(Room room)
    {
        await _roomDal.AddAsync(room);
        return new SuccessDataResult<Room>(room);
    }

    public async Task<IDataResult<Room>> UpdateAsync(Room room)
    {
        if (room is null) return new ErrorDataResult<Room>();

        await _roomDal.UpdateAsync(room);
        return new SuccessDataResult<Room>(room);
    }

    public async Task<IDataResult<Room>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);

        if (!result.Success) return new ErrorDataResult<Room>();

        await _roomDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Room>(result.Data);
    }
}