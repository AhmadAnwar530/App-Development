using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Contracts;
using NoWaste.Domain.Repositories;
using NoWaste.Domain.Seedwork;
using Plugin.LocalNotifications;
using System;
using System.Linq;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NoWaste
{
  public partial class App : Application
  {
    public static IAddItemRepository _itemRepository;
    public static ICategoryRepository _categoryRepository;
    public static ISettingRepository _settingRepository;
    const string HasCategories = "HAS_CATEGORIES";
    const string NoCategory = "NO_CATEGORY";
    const string General = "General";
    public App()
    {
      InitializeComponent();
      SqlLiteFactory.Seed(DependencyService.Get<ISqlLiteConnection>().GetDatabasePath());
      _itemRepository = new AddItemRepository();
      _categoryRepository = new CategoryRepository();
      _settingRepository = new SettingRepository();
      Util.InitializeSetting();
      var nav = new NavigationPage(new NoWasteMainPage());
      nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
      nav.BarTextColor = Color.White;
      if (!Preferences.ContainsKey(HasCategories))
        AddInitialCategories();
      else if (!Preferences.ContainsKey(NoCategory))
      {
        Preferences.Set(NoCategory, true);
        Preferences.Set(General, true);
        _categoryRepository.DeleteAllCategories();
        AddInitialCategories();
      }
      else if (!Preferences.ContainsKey(General))
      {
        Preferences.Set(General, true);
        _categoryRepository.DeleteAllCategories();
        AddInitialCategories();
      }
      MainPage = nav;

    }

    void AddInitialCategories()
    {
      _categoryRepository.AddUpdateCategory(new Category { Name = "General" });
      _categoryRepository.AddUpdateCategory(new Category { Name = "Dairy" });
      _categoryRepository.AddUpdateCategory(new Category { Name = "Fruits & Vegetables" });
      _categoryRepository.AddUpdateCategory(new Category { Name = "Grains & Cereal" });
      _categoryRepository.AddUpdateCategory(new Category { Name = "Bakery" });
      _categoryRepository.AddUpdateCategory(new Category { Name = "Meat & Fish" });
      Preferences.Set(HasCategories, true);
      UpdateItemCategories();
    }

    void UpdateItemCategories()
    {

      var allItems = _itemRepository.GetAllItems().ToList();
      if (allItems != null && allItems.Count > 0)
      {
        var categories = _categoryRepository.GetAllCategories();
        foreach (var category in categories)
        {
          foreach (var item in allItems)
          {
            if (category.Name.ToLower().Contains(item.CategoryName.ToLower()))
            {
              item.CategoryName = category.Name;
              item.CategoryId = category.Id;
              _itemRepository.AddUpdateItem(item);
            }
          }
        }
      }
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
