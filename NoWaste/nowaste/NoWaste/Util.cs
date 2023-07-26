using System;
using NoWaste.Domain.Models.Aggregates;
using NoWaste.Enums;
using NoWaste.Models;

namespace NoWaste
{
  public class Util
  {
    public static Setting CurrentSetting { get; set; }

    public static void InitializeSetting()
    {
      CurrentSetting = App._settingRepository.GetCurrentSetting();
      if (CurrentSetting == null)
      {
        CurrentSetting = new Setting();
        // setting default values
        CurrentSetting.ExpiryNotificationDays = 3;
        CurrentSetting.IsHideExpiry = false;
        CurrentSetting.EnableExpiryAlert = true;
        CurrentSetting.AppVersion = "1.0";
        CurrentSetting.SortOrder = (int)SortEnum.ExpiryAscending;
        CurrentSetting.AddEnableExpiryAlert = true;
        UpdateSetting();
      }
      else
      {
        //setting exists but new version added EnableExpiryAlert
        if (CurrentSetting.AddEnableExpiryAlert == false) //will be false bt default
        {
          CurrentSetting.EnableExpiryAlert = true;
          CurrentSetting.AddEnableExpiryAlert = true;
          UpdateSetting();
        }
      }
    }
    public static void UpdateSetting()
    {
      App._settingRepository.AddUpdateSetting(CurrentSetting);
    }
    public static Item GetItemFromItemModel(ItemModel model)
    {
      var item = new Item();
      item.Barcode = model.Barcode;
      item.DatePurchase = model.DatePurchase;
      item.Expiry = model.Expiry;
      item.Name = model.Name;
      item.CategoryId = model.CategoryId;
      item.Id = model.Id;
      item.CategoryName = model.CategoryName;
      item.IsActive = model.IsActive;
      return item;
    }

    public static ItemModel GetItemModelFromItem(Item item)
    {
      var model = new ItemModel();
      model.Barcode = item.Barcode;
      model.DatePurchase = item.DatePurchase;
      model.Expiry = item.Expiry;
      model.Name = item.Name;
      model.CategoryId = item.CategoryId;
      model.CategoryName = item.CategoryName;
      model.Id = item.Id;
      model.IsActive = item.IsActive;
      return model;
    }
  }
}
