using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Security.Cryptography.X509Certificates;
using NoWaste.ViewModels;
using NoWaste.ViewModels.Categories;

namespace NoWaste.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPopup : PopupPage
    {
        public event Action<List<String>> ApplyCategoryAndExpiryFilters;

        public FilterPopup(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            var viewModel = new FilterPopupViewModel();

            viewModel.OnApplyCategoryAndExpiry += (SelectedCategoryAndExpiry) =>
            {
                mainPageViewModel.ApplyCategoryAndExpiryFilters(SelectedCategoryAndExpiry);
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            };

            BindingContext = viewModel;
        }
    }

}