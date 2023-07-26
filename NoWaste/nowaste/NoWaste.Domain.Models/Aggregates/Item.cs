using NoWaste.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace NoWaste.Domain.Models.Aggregates
{
    public class Item : IdentifiableDomainObject
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime DatePurchase { get; set; } 
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public bool HideInExpiryPopup { get; set; }
    }
}

