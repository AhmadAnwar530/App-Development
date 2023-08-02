using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Common;
using NoWaste.Domain.Models.Contracts;
using NoWaste.Domain.Repositories;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;
using NoWaste.Models;
using NoWaste.Enums;
using Xamarin.Essentials;
using System.Text;
using System.IO;

namespace NoWaste.ViewModels
{
    public class MainPageViewModel : ObservableObject
    {
        private ObservableCollection<ItemModel> _allItemsList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> AllItemsList
        {
            get => _allItemsList;
            set => SetProperty(ref _allItemsList, value);
        }

        private ObservableCollection<ItemModel> _itemsList = new ObservableCollection<ItemModel>();
        public ObservableCollection<ItemModel> ItemsList
        {
            get => _itemsList;
            set => SetProperty(ref _itemsList, value);
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                UpdateList();
            }

        }

        private bool _showCategoryAsc;
        public bool ShowCategoryAsc
        {
            get => _showCategoryAsc;
            set => SetProperty(ref _showCategoryAsc, value);
        }

        private bool _showCategoryDesc;
        public bool ShowCategoryDesc
        {
            get => _showCategoryDesc;
            set => SetProperty(ref _showCategoryDesc, value);
        }

        private bool _showNameAsc;
        public bool ShowNameAsc
        {
            get => _showNameAsc;
            set => SetProperty(ref _showNameAsc, value);
        }

        private bool _showNameDesc;
        public bool ShowNameDesc
        {
            get => _showNameDesc;
            set => SetProperty(ref _showNameDesc, value);
        }

        private bool _showExpiryAsc;
        public bool ShowExpiryAsc
        {
            get => _showExpiryAsc;
            set => SetProperty(ref _showExpiryAsc, value);
        }

        private bool _showExpiryDesc = true;
        public bool ShowExpiryDesc
        {
            get => _showExpiryDesc;
            set => SetProperty(ref _showExpiryDesc, value);
        }
        int ExpiredItemsCount = 0;
        int ExpiringItemsCount = 0;
        int ExpiringDays = 3;
        public MainPageViewModel()
        {
            ExpiringDays = Util.CurrentSetting.ExpiryNotificationDays;
        }

        public void ApplySort(SortEnum sortEnum)
        {
            Util.CurrentSetting.SortOrder = (int)sortEnum;
            Util.UpdateSetting();
            switch (sortEnum)
            {
                case SortEnum.CategoryAscending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderBy((x) => x.CategoryName).ThenByDescending((y) => y.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderBy((x) => x.CategoryName).ThenByDescending((y) => y.Expiry));
                    break;
                case SortEnum.CategoryDescending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderByDescending((x) => x.CategoryName).ThenByDescending((y) => y.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderByDescending((x) => x.CategoryName).ThenByDescending((y) => y.Expiry));
                    break;
                case SortEnum.NameAscending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderBy((x) => x.Name).ThenByDescending((y) => y.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderBy((x) => x.Name).ThenByDescending((y) => y.Expiry));
                    break;
                case SortEnum.NameDescending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderByDescending((x) => x.Name).ThenByDescending((y) => y.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderByDescending((x) => x.Name).ThenByDescending((y) => y.Expiry));
                    break;
                case SortEnum.ExpiryAscending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderBy((x) => x.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderBy((x) => x.Expiry));
                    break;
                case SortEnum.ExpiryDescending:
                    ItemsList = new ObservableCollection<ItemModel>(ItemsList.OrderByDescending((x) => x.Expiry));
                    AllItemsList = new ObservableCollection<ItemModel>(AllItemsList.OrderByDescending((x) => x.Expiry));
                    break;
            }

        }

        public void ShowHideArrows(SortEnum sortEnum)
        {
            ShowCategoryAsc = sortEnum == SortEnum.CategoryDescending;
            ShowCategoryDesc = sortEnum == SortEnum.CategoryAscending;
            ShowNameAsc = sortEnum == SortEnum.NameDescending;
            ShowNameDesc = sortEnum == SortEnum.NameAscending;
            ShowExpiryAsc = sortEnum == SortEnum.ExpiryDescending;
            ShowExpiryDesc = sortEnum == SortEnum.ExpiryAscending;
        }

        void UpdateList()
        {
            if (string.IsNullOrEmpty(SearchText))
                ItemsList = AllItemsList;
            else
            {
                var txt = SearchText.ToLower();
                ItemsList = new ObservableCollection<ItemModel>(AllItemsList.Where((x) => (!string.IsNullOrEmpty(x.Barcode) && x.Barcode.ToLower().Contains(txt)) || (!string.IsNullOrEmpty(x.CategoryName) && x.CategoryName.ToLower().Contains(txt)) || (!string.IsNullOrEmpty(x.Name) && x.Name.ToLower().Contains(txt))));
            }
        }

        //private GridLength _priceColumnWidth = new GridLength(1, GridUnitType.Star);
        //public GridLength PriceColumnWidth
        //{
        //    get => _priceColumnWidth;
        //    set => SetProperty(ref _priceColumnWidth, value);
        //}

        //private GridLength _datePurchaseColumnWidth = new GridLength(1, GridUnitType.Star);
        //public GridLength DatePurchaseColumnWidth
        //{
        //    get => _datePurchaseColumnWidth;
        //    set => SetProperty(ref _datePurchaseColumnWidth, value);
        //}



        private bool _isDatePurchaseVisible;
        public bool IsDatePurchaseVisible
        {
            get => _isDatePurchaseVisible;
            set
            {
                SetProperty(ref _isDatePurchaseVisible, value);
                
            }
        }

        private bool _isPriceVisible;
        public bool IsPriceVisible
        {
            get => _isPriceVisible;
            set
            {
                SetProperty(ref _isPriceVisible, value);
                
            }
        }

        public async void LoadItems(bool IsShowExpiry = true, bool IsShowPrice = true, bool IsShowDatePurchase = true)
        {
            var items = App._itemRepository.GetAllItems().ToList().FindAll((x) => x.IsActive);
         
            if(Util.CurrentSetting.IsPriceVisible == true)
            {
                IsPriceVisible = true;
                //var prices = items
                //.Where(x => x.PurchaseAmount > 0)
                //.Select(x => x.PurchaseAmount)
                //.OrderBy(amount => amount)
                // .ToList();
                items = items.FindAll((x) => x.PurchaseAmount >= 0);
                items = items.OrderBy((x) => x.PurchaseAmount).ToList();

            }

            else if(Util.CurrentSetting.IsPriceVisible == false)
            { 
                IsPriceVisible = false;
              
                //PriceColumnWidth = IsPriceVisible ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }

            if (Util.CurrentSetting.IsDatePurchaseVisible == true)
            {
                IsDatePurchaseVisible = true;
                items = items.FindAll((x) => x.DatePurchase <= DateTime.Today);
                items = items.OrderBy((x) => x.DatePurchase).ToList();
            }
            else if (Util.CurrentSetting.IsDatePurchaseVisible == false) 
            { 
                IsDatePurchaseVisible = false;
                //DatePurchaseColumnWidth = IsDatePurchaseVisible ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }

            if (Util.CurrentSetting.IsHideExpiry)
            {
                items = items.FindAll((x) => x.Expiry > DateTime.Today);
            }
            items = items.OrderBy((x) => x.Expiry).ToList();
            //if (ItemsList == null || items.Count != ItemsList.Count)
            //{
            ItemsList = new ObservableCollection<ItemModel>();
            AllItemsList = new ObservableCollection<ItemModel>();
            foreach (var item in items)
            {
                AllItemsList.Add(Util.GetItemModelFromItem(item));
            }
            UpdateList();
            if (IsShowExpiry && Util.CurrentSetting.EnableExpiryAlert)
            {
                var expiring = items.FindAll((x) => x.Expiry.Date <= DateTime.Today.AddDays(ExpiringDays).Date && x.Expiry.Date >= DateTime.Today.Date);
                var expired = items.FindAll((x) => x.Expiry.Date < DateTime.Today.Date && !x.HideInExpiryPopup);
                var message = "";

                if (expiring.Count == ExpiringItemsCount && expired.Count == ExpiredItemsCount)
                    return;

                ExpiringItemsCount = expiring.Count;
                ExpiredItemsCount = expired.Count;
                if (expiring.Count > 0)
                {


                    foreach (var expireItem in expiring)
                    {
                        var days = expireItem.Expiry.Date.Subtract(DateTime.Today).Days;
                        if (days > 1)
                        {
                            message += $"{expireItem.Name} is expiring in {days} days\n";
                        }
                        else if (days == 0)
                        {
                            message += $"{expireItem.Name} is expiring Today\n";
                        }
                        else
                        {
                            message += $"{expireItem.Name} is expiring in {days} day\n";
                        }
                    }

                }

                if (expired.Count > 0)
                {

                    message += "Expired Items:\n";
                    foreach (var expireItem in expired)
                    {
                        var days = expireItem.Expiry.Date.Subtract(DateTime.Today).Days;
                        if (days == 0)
                        {
                            message += $"{expireItem.Name}  expired today\n";
                        }
                        else if (days == -1)
                        {
                            message += $"{expireItem.Name} is expired 1 day ago\n";
                        }
                        else
                        {
                            var PostivieDay = days.ToString().Replace("-", "");
                            message += $"{expireItem.Name} is expired {PostivieDay} days ago\n";
                        }
                    }
                    var result = await Application.Current.MainPage.DisplayAlert("", message, "Don't show expired items again", "OK");
                    if (result)
                        HideExpiredItemsInPopup(expired);
                }
                else if (expiring.Count > 0)
                {
                    await Application.Current.MainPage.DisplayAlert("", message, "OK");
                }
            }
            //}
        }

        public void HideExpiredItemsInPopup(List<Item> Items)
        {
            foreach (var item in Items)
            {
                item.HideInExpiryPopup = true;
                App._itemRepository.AddUpdateItem(item);
            }
        }

        public void ApplyCategoryFilters(List<string> selectedCategories)
        {
            if (selectedCategories == null || selectedCategories.Count == 0)
            {
                ItemsList = AllItemsList;
            }
            else
            {
                ItemsList = new ObservableCollection<ItemModel>(AllItemsList.Where(x => selectedCategories.Contains(x.CategoryName)));
            }
        }

        public void ApplyExpiryFilters(List<string> selectedExpiry)
        {
            if (selectedExpiry == null || selectedExpiry.Count == 0)
            {
                ItemsList = AllItemsList;
            }
            else
            {
                // Convert each selectedExpiry item into a date
                var expiryDates = selectedExpiry.Select(e =>
                {
                    if (e == "1 Day Ago")
                        return DateTime.Today.AddDays(-1);
                    if (e == "Today")
                        return DateTime.Today;
                    if (e == "Tomorrow")
                        return DateTime.Today.AddDays(1);

                    throw new Exception($"Unknown expiry filter: {e}");
                }).ToList();

                // Only include items where the Expiry date is one of the selected dates
                ItemsList = new ObservableCollection<ItemModel>(
                    AllItemsList.Where(item => expiryDates.Contains(item.Expiry.Date)));
            }
        }





    }
}