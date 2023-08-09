using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace NoWaste.ViewModels
{
    class FilterPopupViewModel : INotifyPropertyChanged
    {
        private bool isSelectAllCategoryChecked;
        public bool IsSelectAllCategoryChecked
        { 
            get => isSelectAllCategoryChecked;
            set
            {
                isSelectAllCategoryChecked = value;
                IsGeneralChecked = value;
                IsDairyChecked = value;
                IsFruitsVegetablesChecked = value;
                IsGrainsCerealChecked = value;
                IsBakeryChecked = value;
                IsMeatFishChecked = value;
                OnPropertyChanged(nameof(IsGeneralChecked));
                OnPropertyChanged(nameof(IsDairyChecked));
                OnPropertyChanged(nameof(IsFruitsVegetablesChecked));
                OnPropertyChanged(nameof(IsGrainsCerealChecked));
                OnPropertyChanged(nameof(IsBakeryChecked));
                OnPropertyChanged(nameof(IsMeatFishChecked));

            }
        }
        private bool isSelectAllChecked;
        public bool IsSelectAllChecked
        {
            get => isSelectAllChecked;
            set
            {
                isSelectAllChecked = value;

                IsOneDayAgoChecked = value;
                IsTodayChecked = value;
                IsTomorrowChecked = value;
                OnPropertyChanged(nameof(IsOneDayAgoChecked));
                OnPropertyChanged(nameof(IsTodayChecked));
                OnPropertyChanged(nameof(IsTomorrowChecked));
            }
        }
        public double ScreenHeight => Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Height * 0.8;

        private string _filterByCategoryHeader = "> Filter by Category";
        public string FilterByCategoryHeader
        {
            get => _filterByCategoryHeader;
            set
            {
                _filterByCategoryHeader = value;
                OnPropertyChanged();
            }
        }

        private string _filterByExpiryHeader = "> Filter by Expiry";
        public string FilterByExpiryHeader
        {
            get => _filterByExpiryHeader;
            set
            {
                _filterByExpiryHeader = value;
                OnPropertyChanged();
            }
        }
        public bool IsCategoryExpanded { get; set; } = false;

        public bool IsExpiryExpanded { get; set; } = false;

        public ICommand ToggleCategoryFilterCommand { get; private set; }
        public ICommand ToggleExpiryFilterCommand { get; private set; }


        public ObservableCollection<string> Categories { get; set; }
        public ObservableCollection<string> Expiry { get; set; }

        public ICommand ApplyCommand { get; set; }

        // Properties for Category checkboxes
        public bool IsGeneralChecked { get; set; }
        public bool IsDairyChecked { get; set; }
        public bool IsFruitsVegetablesChecked { get; set; }
        public bool IsGrainsCerealChecked { get; set; }
        public bool IsBakeryChecked { get; set; }
        public bool IsMeatFishChecked { get; set; }

        // Properties for Expiry checkboxes
        public bool IsOneDayAgoChecked { get; set; }
        public bool IsTodayChecked { get; set; }
        public bool IsTomorrowChecked { get; set; }

        // Selected options
        public List<string> SelectedCategoryAndExpiry { get; set; }

        public FilterPopupViewModel()
        {
            ApplyCommand = new Command(Apply);
            Categories = new ObservableCollection<string>
            {
                "General", "Dairy", "Fruits & Vegetables", "Grains & Cereal", "Bakery", "Meat & Fish"
            };
            Expiry = new ObservableCollection<string>
            {
                "1 Day Ago", "Today", "Tomorrow"
            };
            ToggleCategoryFilterCommand = new Command(ToggleCategoryFilter);
            ToggleExpiryFilterCommand = new Command(ToggleExpiryFilter);
        }

        private void Apply()
        {
            SelectedCategoryAndExpiry = new List<string>();
            if (IsGeneralChecked)
                SelectedCategoryAndExpiry.Add("General");
            if (IsDairyChecked)
                SelectedCategoryAndExpiry.Add("Dairy");
            if (IsFruitsVegetablesChecked)
                SelectedCategoryAndExpiry.Add("Fruits & Vegetables");
            if (IsGrainsCerealChecked)
                SelectedCategoryAndExpiry.Add("Grains & Cereal");
            if (IsBakeryChecked)
                SelectedCategoryAndExpiry.Add("Bakery");
            if (IsMeatFishChecked)
                SelectedCategoryAndExpiry.Add("Meat & Fish");
            if (IsOneDayAgoChecked)
                SelectedCategoryAndExpiry.Add("1 Day Ago");
            if (IsTodayChecked)
                SelectedCategoryAndExpiry.Add("Today");
            if (IsTomorrowChecked)
                SelectedCategoryAndExpiry.Add("Tomorrow");

            OnApplyCategoryAndExpiry?.Invoke(SelectedCategoryAndExpiry);
        }

       
        private void ToggleCategoryFilter()
        {
            IsCategoryExpanded = !IsCategoryExpanded;
            OnPropertyChanged(nameof(IsCategoryExpanded));
            FilterByCategoryHeader = IsCategoryExpanded ? "v Filter by Category" : "> Filter by Category";

        }

        private void ToggleExpiryFilter()
        {
            IsExpiryExpanded = !IsExpiryExpanded;
            OnPropertyChanged(nameof(IsExpiryExpanded));
            FilterByExpiryHeader = IsExpiryExpanded ? "v Filter by Expiry" : "> Filter by Expiry";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        // Separate events for categories and expiry
        public event Action<List<string>> OnApplyCategoryAndExpiry;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
