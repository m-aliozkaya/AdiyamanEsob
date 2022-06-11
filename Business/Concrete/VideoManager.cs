using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class VideoManager : IVideoService
{
    private readonly IVideoDal _videoDal;

    public VideoManager(IVideoDal videoDal)
    {
        _videoDal = videoDal;
    }
    
    public async Task<IDataResult<Video>> GetAsync(int id)
    {
        var result = await _videoDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Video>(result); 
        }

        return new ErrorDataResult<Video>();
    }

    public async Task<IDataResult<List<Video>>> GetListAsync()
    {
        var result = await _videoDal.GetAllAsync();
        return new SuccessDataResult<List<Video>>(result);
    }

    public async Task<IDataResult<Video>> AddAsync(Video video)
    {
        await _videoDal.AddAsync(video);
        return new SuccessDataResult<Video>(video);
    }

    public async Task<IDataResult<Video>> UpdateAsync(Video video)
    {
        if (video is null) return new ErrorDataResult<Video>();
        
        await _videoDal.UpdateAsync(video);
        return new SuccessDataResult<Video>(video);
    }

    public async Task<IDataResult<Video>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Video>();
        
        await _videoDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Video>(result.Data);
    }
}