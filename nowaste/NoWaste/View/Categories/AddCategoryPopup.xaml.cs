using System;
using System.Collections.Generic;

using NoWaste.Domain.Models.Aggregates;
using NoWaste.ViewModels.Categories;

using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace NoWaste.View.Categories
{
  public partial class AddCategoryPopup : PopupPage
  {
    Category category;
    AddCategoryViewModel VM;
    public Action<Category> CategoryAddedOrUpdated;
    public Action CategoryDeleted;
    public AddCategoryPopup(Category category)
    {
      this.category = category;
      InitializeComponent();
      VM = new AddCategoryViewModel();
      VM.CategoryAddedOrUpdated += (c) =>
      {
        CategoryAddedOrUpdated?.Invoke(c);
      };
      VM.CategoryDeleted += () =>
      {
        CategoryDeleted?.Invoke();
      };
      if (category != null)
      {
        VM.category = category;
        VM.Name = category.Name;
        VM.SaveEditText = "Update";
        VM.IsDeleteShow = true;
      }
      BindingContext = VM;
    }
  }
}
