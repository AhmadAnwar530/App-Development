using ScreenTemplate.Models;
using ScreenTemplate.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        private readonly User user;

        public EditUserPage(User user)
        {
            InitializeComponent();
            this.user = user;
            BindingContext = new EditUserModel(user);
        }
    }
   
}
