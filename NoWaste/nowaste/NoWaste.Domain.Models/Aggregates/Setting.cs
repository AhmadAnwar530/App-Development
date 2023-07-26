using System;
using NoWaste.Domain.Models.Common;

namespace NoWaste.Domain.Models.Aggregates
{
  public class Setting : IdentifiableDomainObject
  {
    public string AppVersion { get; set; }
    public bool IsHideExpiry { get; set; }
    public bool EnableExpiryAlert { get; set; }
    public int ExpiryNotificationDays { get; set; }
    public int SortOrder { get; set; }
    public bool AddEnableExpiryAlert { get; set; }
  }
}
