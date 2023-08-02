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
using Plugin.LocalNotifications;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using NoWaste.View.Categories;

namespace NoWaste.ViewModels
{
    public class AddItemViewModel : ObservableObject
    {
        ItemModel _item = new ItemModel();
        public ItemModel Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        ObservableCollection<Category> _categories;
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set => SetProperty(ref _categories, value);
        }

        Category _selectedCategory;
        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                SetProperty(ref _selectedCategory, value);
                UpdateCategoryButton();
            }
        }

        string _daysText = "Today";
        public string DaysText
        {
            get => _daysText;
            set => SetProperty(ref _daysText, value);
        }

        string _purchasedaysText = "Today";
        public string PurchaseDaysText
        {
            get => _purchasedaysText;
            set => SetProperty(ref _purchasedaysText, value);
        }


        string _saveEditText = "Save";
        public string SaveEditText
        {
            get => _saveEditText;
            set => SetProperty(ref _saveEditText, value);
        }

        string _title = "Add Item";
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isEditable = true;
        public bool IsEditable
        {
            get => _isEditable;
            set => SetProperty(ref _isEditable, value);
        }

        bool _isAddCategoryShow = true;
        public bool IsAddCategoryShow
        {
            get => _isAddCategoryShow;
            set => SetProperty(ref _isAddCategoryShow, value);
        }

        bool _isUpdateCategoryShow;
        public bool IsUpdateCategoryShow
        {
            get => _isUpdateCategoryShow;
            set => SetProperty(ref _isUpdateCategoryShow, value);
        }

        bool _showDelete;
        public bool ShowDelete
        {
            get => _showDelete;
            set => SetProperty(ref _showDelete, value);
        }



        public Command ScanCommand { get; set; }
        public Command CategoryAddCommand { get; set; }
        public Command CategoryUpdateCommand { get; set; }
        public Command SaveCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public List<Item> AllItems;
        public Action DontFocusEntry;
        public ObservableCollection<string> NamesList = new ObservableCollection<string>();
        public AddItemViewModel()
        {
            ScanCommand = new Command(async () => await ScanCommandRun());
            SaveCommand = new Command(async () => await SaveCommandRun());
            DeleteCommand = new Command(async () => await DeleteCommandRun());
            CategoryAddCommand = new Command(async () => await CategoryAddCommandRun());
            CategoryUpdateCommand = new Command(async () => await CategoryUpdateCommandRun());
            Categories = new ObservableCollection<Category>(App._categoryRepository.GetAllCategories());
            DontFocusEntry?.Invoke();
            if (!string.IsNullOrEmpty(Item.CategoryName))
                SelectedCategory = Categories.ToList().FirstOrDefault((x) => x.Name == Item.CategoryName);


        }

        public void UpdateCategoryButton()
        {
            IsAddCategoryShow = SelectedCategory == null || SelectedCategory.Name == "General";
            IsUpdateCategoryShow = !IsAddCategoryShow;

        }

        public void UpdateItemWithFoundValues(string name)
        {
            var itemFound = AllItems.Find((x) => x.Name == name);
            if (itemFound != null)
            {
                Item.CategoryName = itemFound.CategoryName;
                Item.CategoryId = itemFound.CategoryId;
                Item.Barcode = itemFound.Barcode;
                UpdateSelectedCategory();
            }
        }

        public void GetNames()
        {
            AllItems = App._itemRepository.GetAllItems().ToList();
            foreach (var item in AllItems)
            {
                if (!string.IsNullOrEmpty(item.Name) && !NamesList.Contains(item.Name))
                    NamesList.Add(item.Name);
            }
        }

        public void UpdateValues(bool IsUpdate)
        {
            ShowDelete = IsUpdate;
        }

        public void UpdateSaveEditText()
        {
            SaveEditText = IsEditable ? "Save" : "Edit";
        }

        public void UpdateDays()
        {
            var span = Item.Expiry.Date.Subtract(DateTime.Today);
            if (span.TotalDays == 0)
            {
                DaysText = "Today";
            }
            else if (span.TotalDays == -1)
            {
                DaysText = "1 day ago";
            }
            else if (span.TotalDays == 1)
            {
                DaysText = "Tomorrow";
            }
            else if (span.TotalDays < -1)
            {
                DaysText = $"{Math.Abs(span.TotalDays)} days ago";
            }
            else if (span.TotalDays > 1)
            {
                DaysText = $"{span.TotalDays} days";
            }
        }

        public void PrchaseUpdateDays()
        {
            var span = Item.Expiry.Date.Subtract(DateTime.Today);
            if (span.TotalDays == 0)
            {
                PurchaseDaysText = "Today";
            }
            else if (span.TotalDays == -1)
            {
                PurchaseDaysText = "1 day ago";
            }
            else if (span.TotalDays == 1)
            {
                PurchaseDaysText = "Tomorrow";
            }
            else if (span.TotalDays < -1)
            {
                PurchaseDaysText = $"{Math.Abs(span.TotalDays)} days ago";
            }
            else if (span.TotalDays > 1)
            {
                PurchaseDaysText = $"{span.TotalDays} days";
            }
        }
        public void UpdateSelectedCategory()
        {
            DontFocusEntry?.Invoke();
            if (!string.IsNullOrEmpty(Item.CategoryName))
                SelectedCategory = Categories.ToList().FirstOrDefault((x) => x.Name == Item.CategoryName);

        }

        async Task CategoryAddCommandRun()
        {
            var popup = new AddCategoryPopup(null);
            popup.CategoryAddedOrUpdated += UpdateCategories;
            await PopupNavigation.Instance.PushAsync(popup);
        }
        async Task CategoryUpdateCommandRun()
        {
            var popup = new AddCategoryPopup(SelectedCategory);
            popup.CategoryAddedOrUpdated += UpdateCategories;
            popup.CategoryDeleted += UpdateCategories;
            await PopupNavigation.Instance.PushAsync(popup);
        }

        void UpdateCategories(Category category)
        {
            Categories = new ObservableCollection<Category>(App._categoryRepository.GetAllCategories());
            SelectedCategory = Categories.FirstOrDefault((x) => x.Name == category.Name);
        }

        void UpdateCategories()
        {
            Categories = new ObservableCollection<Category>(App._categoryRepository.GetAllCategories());
            SelectedCategory = null;
        }

        async Task ScanCommandRun()
        {
            var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
            options.PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>() {
            ZXing.BarcodeFormat.All_1D, ZXing.BarcodeFormat.QR_CODE,
            };

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var _barcode = await scanner.Scan(options);
            if (_barcode != null && !string.IsNullOrEmpty(_barcode.ToString()))
            {
                Item.Barcode = _barcode.ToString();
                var itemFound = App._itemRepository.GetItemByBarcode(Item.Barcode);
                if (itemFound != null)
                {
                    Item.Name = itemFound.Name;
                    Item.CategoryId = itemFound.CategoryId;
                    Item.CategoryName = itemFound.CategoryName;
                    DontFocusEntry?.Invoke();
                    SelectedCategory = Categories.ToList().FirstOrDefault((x) => x.Name == itemFound.CategoryName);
                }
            }
        }

        async Task SaveCommandRun()
        {
            if (IsEditable)
            {
                if (string.IsNullOrWhiteSpace(Item.Name))
                {
                    await Application.Current.MainPage.DisplayAlert("", "Please enter name", "OK");
                    return;
                }

                //if(!string.IsNullOrWhiteSpace(Item.Barcode))
                //{
                //    var alreadyFound = App._itemRepository.GetAllItems().Where((x) => x.IsActive && x.Barcode == Item.Barcode).FirstOrDefault();
                //    if(alreadyFound!=null)
                //    {
                //        await Application.Current.MainPage.DisplayAlert("", "Item with this barcode is already saved please enter different barcode", "OK");
                //        return;
                //    }
                //}
                if (SelectedCategory == null)
                {
                    SelectedCategory = Categories[0];
                }
                Item.CategoryId = SelectedCategory.Id;
                Item.CategoryName = SelectedCategory.Name;
                // await DisplayAlert("Barcode scan successful", "Here are the results:", " " + _barcode);
                App._itemRepository.AddUpdateItem(Util.GetItemFromItemModel(Item));
                await Application.Current.MainPage.Navigation.PopAsync();
                CrossToastPopUp.Current.ShowToastMessage($"{Item.Name} added successfully (Expiring in {Math.Round(Item.Expiry.Subtract(DateTime.Today).TotalDays)} days)", Plugin.Toast.Abstractions.ToastLength.Long);
                CrossLocalNotifications.Current.Show("Expiry", $"{Item.Name} is expiring within next 3 days.", 101, Item.Expiry.AddDays(-3));
            }
            else
            {
                IsEditable = true;
                UpdateSaveEditText();
            }
        }

        async Task DeleteCommandRun()
        {
            var result = await Application.Current.MainPage.DisplayActionSheet("Do you really want to delete?", "Cancel", "", "Remove from Inventory", "Permanently Remove");
            if (result == "Remove from Inventory")
            {
                var itmToUpdate = Util.GetItemFromItemModel(Item);
                itmToUpdate.IsActive = false;
                App._itemRepository.AddUpdateItem(itmToUpdate);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            else if (result == "Permanently Remove")
            {
                var itmToUpdate = Util.GetItemFromItemModel(Item);
                App._itemRepository.DelteItem(itmToUpdate);
                await Application.Current.MainPage.Navigation.PopAsync();
            }

        }
    }
}