using Business.Abstract;
using Core.Utilities.Mails.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Entity;

namespace Business.Concrete;

public class SettingManager : ISettingService
{
    private readonly ISettingDal _settingDal;

        public SettingManager(ISettingDal settingDal)
        {
            _settingDal = settingDal;
        }

        public async Task<IResult> AddAsync(Setting setting)
        {
            await _settingDal.AddAsync(setting);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var deletedSetting = await _settingDal.GetAsync(x => x.Id == id);
            await _settingDal.DeleteAsync(deletedSetting);
            return new SuccessResult();
        }

        public async Task<IDataResult<List<Setting>>> GetAllAsync()
        {
            var settings = await _settingDal.GetAllAsync();
            return new SuccessDataResult<List<Setting>>(settings);
        }

        public async Task<IDataResult<Setting>> GetByIdAsync(int id)
        {
            var setting = await _settingDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<Setting>(setting);
        }
        

        public async Task<IResult> UpdateAsync(Setting setting)
        {
            await _settingDal.UpdateAsync(setting);
            return new SuccessResult();
        }
}