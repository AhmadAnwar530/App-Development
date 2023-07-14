using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ScreenTemplate.Views;
using ScreenTemplate.Models;
using ScreenTemplate.ViewModels;
using System.Collections.ObjectModel;

namespace ScreenTemplate.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoList : ContentPage
    {
        ObservableCollection<ToDoListModel> myList;
        public ToDoList()
        {
            InitializeComponent();
             myList = new ObservableCollection<ToDoListModel>
            {
               new ToDoListModel{Title="Project1", Details="Build New Page of the app! Make it Dynamic and add three classes to it.",ImageUrl="https://img.icons8.com/ios/50/task.png"},
                new ToDoListModel{Title="Project2", Details="Maintainence of Old Page of the app! There are some errors in it, fix them.",ImageUrl="https://img.icons8.com/external-icongeek26-glyph-icongeek26/64/external-Maintainance-aviation-icongeek26-glyph-icongeek26.png"},
                 new ToDoListModel{Title="Project3", Details="Fix Bugs of Old Page of the app! One page is not working, check it and try to fix.",ImageUrl="https://img.icons8.com/external-outline-berkahicon/64/external-Bugs-web-development-outline-berkahicon.png"},
                  new ToDoListModel{Title="Project4", Details="UI Design New Page of the app! Should be Modern and good.",ImageUrl="https://img.icons8.com/ios/50/design--v1.png"},
                   new ToDoListModel{Title="Project5", Details="Meeting at 2 at Noon! Scrum Meeting must attend and give feedback.",ImageUrl="https://img.icons8.com/ios/50/meeting-room.png"}

            };
            myListView.ItemsSource = myList;
          
        }
        private void Delete(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var todolist = menuItem.CommandParameter as ToDoListModel;
            myList.Remove(todolist);

        }
        private void Remianed(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var todolist = menuItem.CommandParameter as ToDoListModel;
            DisplayAlert(todolist.Title, todolist.Details, "Complete It!");
        }
    }
}