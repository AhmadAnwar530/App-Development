using System;
using System.Linq;
using NoWaste.Domain.Common;
using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Contracts;

namespace NoWaste.Domain.Repositories
{
    public class SettingRepository : BaseRepository,ISettingRepository
    {
        public Setting GetCurrentSetting()
        {
            return Query<Setting>("select * from Setting").FirstOrDefault();
        }
        public void AddUpdateSetting(Setting setting)
        {
            if (setting.Id > 0)
            {
                Update(setting);
            }
            else
            {
                Insert(setting);
            }
        }
    }
}
