using Core.Utilities.Result.Abstract;
using Entities.Entity;

namespace Business.Abstract;

public interface IProjectService
{
    Task<IDataResult<Project>> GetAsync(int id);
    Task<IDataResult<List<Project>>> GetListAsync();
    Task<IDataResult<Project>> AddAsync(Project project);
    Task<IDataResult<Project>> UpdateAsync(Project project);
    Task<IDataResult<Project>> DeleteAsync(int id);
}