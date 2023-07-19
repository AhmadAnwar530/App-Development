using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace ScreenTemplate
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(MyEntry), 0);
        public int CornerRadius { 
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); } 
        }
    }
}
