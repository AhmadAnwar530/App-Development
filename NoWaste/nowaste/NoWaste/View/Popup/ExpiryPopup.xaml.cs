using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;
using System.Security.Cryptography.X509Certificates;
using NoWaste.ViewModels;
using NoWaste.ViewModels.Categories;

namespace NoWaste.View.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpiryPopup : PopupPage
    {
        public event Action<List<String>> ApplyFilters;
        public ExpiryPopup(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            var viewModel = new ExpiryPopupViewModel();
            viewModel.OnApply += (selectedExpiry) =>
            {
                mainPageViewModel.ApplyExpiryFilters(selectedExpiry);
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            };

            BindingContext = viewModel;
        }



    }
}