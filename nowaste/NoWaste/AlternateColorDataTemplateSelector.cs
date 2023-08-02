using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using NoWaste.Models;

using Xamarin.Forms;

namespace NoWaste
{
    public class AlternateColorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EvenTemplate { get; set; }
        public DataTemplate UnevenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            try
            {
                // TODO: Maybe some more error handling here
                var con = ((ListView)container);
                var list = ((ObservableCollection<ItemModel>)con.ItemsSource);
                var itm = item as ItemModel;
                return list.IndexOf(itm) % 2 == 0 ? EvenTemplate : UnevenTemplate;
            }
            catch(Exception ex)
            {

            }
            return UnevenTemplate;
        }
    }
}
