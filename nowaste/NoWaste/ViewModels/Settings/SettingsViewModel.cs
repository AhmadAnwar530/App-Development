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
        bool _isDatePurchaseVisible;
        public bool IsDatePurchaseVisible
        {
            get => _isDatePurchaseVisible;
            set
            {
                SetProperty(ref _isDatePurchaseVisible, value);
                UpdateDatePurchase();
            }
        }

        bool _isPriceVisible;
        public bool IsPriceVisible
        {
            get => _isPriceVisible;
            set
            {
                SetProperty(ref _isPriceVisible, value);
                UpdatePrice();
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
    public Action DatePurchaseChanged;
        public Action PriceChanged;
    void UpdateExpiryNotificationDays()
    {
      if (Util.CurrentSetting.ExpiryNotificationDays != ExpiryNotificationDays)
      {
        Util.CurrentSetting.ExpiryNotificationDays = ExpiryNotificationDays;
        Util.UpdateSetting();
      }
    }
        private GridLength _priceColumnWidth = new GridLength(1, GridUnitType.Star);
        public GridLength PriceColumnWidth
        {
            get => _priceColumnWidth;
            set => SetProperty(ref _priceColumnWidth, value);
        }

        private GridLength _datePurchaseColumnWidth = new GridLength(1, GridUnitType.Star);
        public GridLength DatePurchaseColumnWidth
        {
            get => _datePurchaseColumnWidth;
            set => SetProperty(ref _datePurchaseColumnWidth, value);
        }

        void UpdatePrice()
        {
            if (Util.CurrentSetting.IsPriceVisible != IsPriceVisible)
            {
                Util.CurrentSetting.IsPriceVisible = IsPriceVisible;
                Util.UpdateSetting();
                OnPropertyChanged(nameof(PriceColumnWidth));
                PriceChanged?.Invoke();
            }
        }

        void UpdateDatePurchase()
        {
            if (Util.CurrentSetting.IsDatePurchaseVisible != IsDatePurchaseVisible)
            {
                Util.CurrentSetting.IsDatePurchaseVisible = IsDatePurchaseVisible;
                Util.UpdateSetting();
                OnPropertyChanged(nameof(DatePurchaseColumnWidth));
                DatePurchaseChanged?.Invoke();
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
      IsDatePurchaseVisible = Util.CurrentSetting.IsDatePurchaseVisible;
            IsPriceVisible = Util.CurrentSetting.IsPriceVisible;

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
