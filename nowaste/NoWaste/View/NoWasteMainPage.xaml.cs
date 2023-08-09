using NoWaste.Domain.Models.Aggregates;
using NoWaste.Enums;
using NoWaste.Models;
using NoWaste.View.Settings;
using NoWaste.View.Sort;
using NoWaste.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Essentials;
using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NoWaste.View.Popup;

namespace NoWaste
{
    public partial class NoWasteMainPage : ContentPage
    {
        public MainPageViewModel VM;

        public NoWasteMainPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            VM = new MainPageViewModel();
            BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            VM.LoadItems();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //void listView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        //{
        //    Navigation.PushAsync(new NoWasteAddItem((ItemModel)e.Item));
        //}

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NoWasteAddItem());
        }

        void Search_Clicked(System.Object sender, System.EventArgs e)
        {
            search.IsVisible = !search.IsVisible;
            VM.SearchText = string.Empty;
        }

        

        void Sort_Clicked(System.Object sender, System.EventArgs e)
        {
            var popup = new SortPopup();
            popup.Apply += ApplySort;
            PopupNavigation.Instance.PushAsync(popup);
        }

        void ApplySort(SortEnum sortEnum)
        {
            VM.ApplySort(sortEnum);
        }

        void SettingItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var settingsPopup = new SettingsPopup();
            settingsPopup.SettingChanged += (IsShowExpiry) => { VM.LoadItems(IsShowExpiry); };
            settingsPopup.SettingChanged += (IsShowPrice) => { VM.LoadItems (IsShowPrice); };
            settingsPopup.SettingChanged += (IsShowDatePurchase) => { VM.LoadItems(IsShowDatePurchase); };
            PopupNavigation.Instance.PushAsync(settingsPopup);
        }

        void Filter_Clicked(System.Object sender, System.EventArgs e)
        {
            var filterPopup = new FilterPopup(VM);
            filterPopup.ApplyCategoryAndExpiryFilters += (SelectedCategoryAndExpiry) =>
            {
                try
                {
                    VM.ApplyCategoryAndExpiryFilters(SelectedCategoryAndExpiry);
                    PopupNavigation.Instance.PopAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying filters and closing popup: {ex}");
                }
            };
            PopupNavigation.Instance.PushAsync(filterPopup);
        }

        void Name_Tapped(System.Object sender, System.EventArgs e)
        {
            var sort = VM.ShowNameDesc ? SortEnum.NameDescending : SortEnum.NameAscending;
            ApplySort(sort);
            VM.ShowHideArrows(sort);
        }

        void Category_Tapped(System.Object sender, System.EventArgs e)
        {
            var sort = VM.ShowCategoryDesc ? SortEnum.CategoryDescending : SortEnum.CategoryAscending;
            ApplySort(sort);
            VM.ShowHideArrows(sort);
            var categoryPopup = new CategoryPopup(VM);
            categoryPopup.ApplyFilters += (selectedCategories) =>
            {
                try
                {
                    VM.ApplyCategoryFilters(selectedCategories);
                    PopupNavigation.Instance.PopAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying filters and closing popup: {ex}");
                }
            };
            PopupNavigation.Instance.PushAsync(categoryPopup);
        }


        void Expiry_Tapped(System.Object sender, System.EventArgs e)
        {
            var sort = !VM.ShowExpiryDesc ? SortEnum.ExpiryAscending : SortEnum.ExpiryDescending;
            ApplySort(sort);
            VM.ShowHideArrows(sort);

            var expiryPopup = new ExpiryPopup(VM);
            expiryPopup.ApplyFilters += (selectedExpiry) =>
            {
                try
                {
                    VM.ApplyExpiryFilters(selectedExpiry);
                    PopupNavigation.Instance.PopAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error applying filters and closing popup: {ex}");
                }
            };
            PopupNavigation.Instance.PushAsync(expiryPopup);
        }

        //Convert List View to CSV format using Observable Collection
        public string ConvertToCSV(ObservableCollection<ItemModel> items)
        {
            var csv = new StringBuilder();

            csv.AppendLine("Name,CategoryName,Amount,PurchaseDate,Expiry"); // header row

            foreach (var item in items)
            {
                var row = $"{item.Name},{item.CategoryName},{item.PurchaseAmount},{item.DatePurchase},{item.Expiry}";
                csv.AppendLine(row);
            }

            return csv.ToString();
        }

        //Save CSV data to a file
        private async Task<string> SaveCSVToFile(string csv)
        {
            var fileName = $"Items_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            var file = Path.Combine(FileSystem.CacheDirectory, fileName);
            File.WriteAllText(file, csv);
            return file;
        }

        //Share csv file
        private async Task ShareFile(string file)
        {
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Share CSV File",
                File = new ShareFile(file)

            });
        }

        private async void ExportButton_Clicked(object sender, System.EventArgs e)
        {

            bool shouldExport = await DisplayAlert(
                "Export Confirmation",
                "You are about to share the current list.\n\nIf you wish to filter your list before sharing, click the filter icon.", 
                "OK", 
                "Exit"
            );

            if (shouldExport)
            {
                var csv = ConvertToCSV(VM.ItemsList);
                var file = await SaveCSVToFile(csv);
                await ShareFile(file);
            }
            else
            {
                // Optionally, you can guide the user to another step after clicking 'Exit'. 
                // For instance, navigate to another page or show a tip. 
                // But if you just want to close the alert and do nothing, leave this section blank.
            }
        }



    }
}