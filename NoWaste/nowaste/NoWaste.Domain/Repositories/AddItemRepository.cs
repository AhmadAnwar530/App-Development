using NoWaste.Domain.Common;
using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoWaste.Domain.Repositories
{
    public class AddItemRepository : BaseRepository, IAddItemRepository
    {
        public IEnumerable<Item> GetAllItems()
        {
            return Query<Item>("select * from Item");
        }

        public void AddUpdateItem(Item item)
        {
            if (item.Id > 0)
            {
                Update(item);
            }
            else
            {
                Insert(item);
            }
        }

        public void DelteItem(Item item)
        {
            Delete(item);
            
        }

        public Item GetItemByBarcode(string barcode)
        {
            return Query<Item>("select * from Item where Barcode='" + barcode + "'").FirstOrDefault();
        }
    }
}
