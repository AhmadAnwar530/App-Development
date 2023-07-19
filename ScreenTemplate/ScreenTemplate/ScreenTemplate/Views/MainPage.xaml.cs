using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScreenTemplate.ViewModels;
using Xamarin.Forms;
using ScreenTemplate.Models;

namespace ScreenTemplate.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }
    }
   
}
