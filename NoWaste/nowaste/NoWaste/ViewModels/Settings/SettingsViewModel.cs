using System;
using System.Collections.Generic;
using NoWaste.Domain.Models.Common;
using Xamarin.Forms;

namespace NoWaste.ViewModels.Settings
{
  public class SettingsViewModel : ObservableObject
  {
    string _appVersion;
    public string AppVersion
    {
      get => _appVersion;
      set => SetProperty(ref _appVersion, value);
    }

    int _expiryNotificationDays;
    public int ExpiryNotificationDays
    {
      get => _expiryNotificationDays;
      set
      {
        SetProperty(ref _expiryNotificationDays, value);
        UpdateExpiryNotificationDays();
      }
    }

    bool _isHideExpiry;
    public bool IsHideExpiry
    {
      get => _isHideExpiry;
      set
      {
        SetProperty(ref _isHideExpiry, value);
        UpdateHideExpiry();
      }
    }

    bool _enableAlert;
    public bool EnableAlert
    {
      get => _enableAlert;
      set
      {
        SetProperty(ref _enableAlert, value);
        UpdateExpiryAlert();
      }
    }

    List<int> _days;
    public List<int> Days
    {
      get => _days;
      set => SetProperty(ref _days, value);
    }

    public Action HideExpiryChanged;
    void UpdateExpiryNotificationDays()
    {
      if (Util.CurrentSetting.ExpiryNotificationDays != ExpiryNotificationDays)
      {
        Util.CurrentSetting.ExpiryNotificationDays = ExpiryNotificationDays;
        Util.UpdateSetting();
      }
    }

    void UpdateHideExpiry()
    {
      if (Util.CurrentSetting.IsHideExpiry != IsHideExpiry)
      {
        Util.CurrentSetting.IsHideExpiry = IsHideExpiry;
        Util.UpdateSetting();
        HideExpiryChanged?.Invoke();
      }
    }

    void UpdateExpiryAlert()
    {
      if (Util.CurrentSetting.EnableExpiryAlert != EnableAlert)
      {
        Util.CurrentSetting.EnableExpiryAlert = EnableAlert;
        Util.UpdateSetting();
      }
    }


    public SettingsViewModel()
    {
      IsHideExpiry = Util.CurrentSetting.IsHideExpiry;

      var versionName = DependencyService.Get<IAppInfo>().GetAppVersion();

      AppVersion = versionName;
      ExpiryNotificationDays = Util.CurrentSetting.ExpiryNotificationDays;
      EnableAlert = Util.CurrentSetting.EnableExpiryAlert;

      Days = new List<int>();
      for (int i = 1; i <= 30; i++)
      {
        Days.Add(i);
      }
    }
  }
}
