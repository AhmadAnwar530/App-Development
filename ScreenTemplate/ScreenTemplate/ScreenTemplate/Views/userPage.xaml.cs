using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenTemplate.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScreenTemplate.ViewModels;

namespace ScreenTemplate.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class userPage : ContentPage
	{
		public userPage()
		{
            InitializeComponent();
            // Retrieve the email and password from the database
            BindingContext  = new UserPageViewModel();
             

        }

	}
}