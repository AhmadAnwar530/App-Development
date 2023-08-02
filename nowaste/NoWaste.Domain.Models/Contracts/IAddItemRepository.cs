using NoWaste.Domain.Models.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoWaste.Domain.Models.Contracts
{
    public interface IAddItemRepository
    {
        IEnumerable<Item> GetAllItems();
        void AddUpdateItem(Item item);
        void DelteItem(Item item);
        Item GetItemByBarcode(string barcode);
    }
}
