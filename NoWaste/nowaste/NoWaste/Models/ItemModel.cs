using System;
using NoWaste.Domain.Models.Common;

namespace NoWaste.Models
{
    public class ItemModel : ObservableObject
    {
        int _id;
            public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set => SetProperty(ref _categoryName, value);
        }

        int _categoryId;
        public int CategoryId
        {
            get => _categoryId;
            set => SetProperty(ref _categoryId, value);
        }

        DateTime _expiry = DateTime.Today;
        public DateTime Expiry
        {
            get => _expiry;
            set { SetProperty(ref _expiry, value);
                SetExpiry();
            }
        }

        DateTime _datePurchase = DateTime.Today;
        public DateTime DatePurchase
        {
            get => _datePurchase;
            set => SetProperty(ref _datePurchase, value);
        }

        string _barcode;
        public string Barcode
        {
            get => _barcode;
            set => SetProperty(ref _barcode, value);
        }

        bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        bool _isExpiringSoon = false;
        public bool IsExpiringSoon
        {
            get => _isExpiringSoon;
            set => SetProperty(ref _isExpiringSoon, value);
        }

        bool _isExpired = false;
        public bool IsExpired
        {
            get => _isExpired;
            set => SetProperty(ref _isExpired, value);
        }

        public void SetExpiry()
        {
            IsExpired = Expiry.Date < DateTime.Today.Date;
            IsExpiringSoon = Expiry.Date <= DateTime.Today.AddDays(Util.CurrentSetting.ExpiryNotificationDays).Date;
        }

    }
}
