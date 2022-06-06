using Business.Abstract;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class ProjectManager : IProjectService
{
    private readonly IProjectDal _projectDal;

    public ProjectManager(IProjectDal projectDal)
    {
        _projectDal = projectDal;
    }
    
    public async Task<IDataResult<Project>> GetAsync(int id)
    {
        var result = await _projectDal.GetAsync(x => x.Id == id);

        if (result is not null)
        {
            return new SuccessDataResult<Project>(result); 
        }

        return new ErrorDataResult<Project>();
    }

    public async Task<IDataResult<List<Project>>> GetListAsync()
    {
        var result = await _projectDal.GetAllAsync();
        return new SuccessDataResult<List<Project>>(result);
    }

    public async Task<IDataResult<Project>> AddAsync(Project project)
    {
        await _projectDal.AddAsync(project);
        return new SuccessDataResult<Project>(project);
    }

    public async Task<IDataResult<Project>> UpdateAsync(Project project)
    {
        if (project is null) return new ErrorDataResult<Project>();
        
        await _projectDal.UpdateAsync(project);
        return new SuccessDataResult<Project>(project);
    }

    public async Task<IDataResult<Project>> DeleteAsync(int id)
    {
        var result = await GetAsync(id);
        
        if (!result.Success) return new ErrorDataResult<Project>();
        
        await _projectDal.DeleteAsync(result.Data);
        return new SuccessDataResult<Project>(result.Data);
    }
}