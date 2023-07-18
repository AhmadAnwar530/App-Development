using ScreenTemplate.Models;
using ScreenTemplate.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ScreenTemplate.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]

   
    public partial class AddUser : ContentPage
    {
        public AddUserViewModel Model { get; set; }
        public AddUser()
        {
            InitializeComponent();

            Model = new AddUserViewModel();
            BindingContext = Model;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Model.RefreshUsers();

        }
    }
}