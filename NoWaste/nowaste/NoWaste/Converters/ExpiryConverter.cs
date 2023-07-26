using System;
using System.Globalization;

using Xamarin.Forms;

namespace NoWaste
{
  public class ExpiryConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var expiry = (DateTime)value;
      var days = expiry.Date.Subtract(DateTime.Today).Days;
      if (days > 1)
        return $"{expiry.ToString("dd/MM/yy")} ({days} days)";

      if (days == 1)
        return $"{expiry.ToString("dd/MM/yy")} (1 day)";

      if (days == 0)
        return $"{expiry.ToString("dd/MM/yy")} (Today)";

      if (days == -1)
        return $"{expiry.ToString("dd/MM/yy")} (1 day ago)";

      //if (days < -1)
      return $"{expiry.ToString("dd/MM/yy")} ({Math.Abs(days)} days ago)";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return null;
    }
  }
}
