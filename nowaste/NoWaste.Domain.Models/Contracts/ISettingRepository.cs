using System;
using System.Collections.Generic;
using NoWaste.Domain.Models.Aggregates;

namespace NoWaste.Domain.Models.Contracts
{
    public interface ISettingRepository
    {
        Setting GetCurrentSetting();
        void AddUpdateSetting(Setting setting);
    }
}
