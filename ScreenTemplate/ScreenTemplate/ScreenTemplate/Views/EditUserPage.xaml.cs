using ScreenTemplate.Models;
using ScreenTemplate.ViewModels;
using ScreenTemplate.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUserPage : ContentPage
    {
        private readonly UserData user;

        public EditUserPage(UserData user)
        {
            InitializeComponent();
            this.user = user;
            BindingContext = new EditUserModel(user);
        }
    }
   
}

//private readonly User user;
//This line declares a private read -only field user of type User. It will store the user object that is passed to the constructor.

//public EditUserPage(User user)
//This is the constructor method for the EditUserPage class. It takes a User object as a parameter. This constructor is used to initialize the page when it is being created.
//this.user = user;
//This assigns the user parameter to the user field of the class. It stores the user object that will be edited so that it can be accessed within the class.

//BindingContext = new EditUserModel(user);
//This line creates a new instance of the EditUserModel class and sets it as the binding context of the page. The EditUserModel constructor is called with the user object as a parameter
//    . This ensures that the EditUserModel instance will be used for data binding with the UI elements defined in the XAML.