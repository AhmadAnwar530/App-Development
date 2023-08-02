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
    public partial class CategoryPopup : PopupPage
    {
        public event Action<List<String>> ApplyFilters;
        public CategoryPopup(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();

            var viewModel = new CategoryPopupViewModel();
            viewModel.OnApply += (selectedCategories) =>
            {
                mainPageViewModel.ApplyCategoryFilters(selectedCategories);
                Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
            };

            BindingContext = viewModel;
        }



    }
}