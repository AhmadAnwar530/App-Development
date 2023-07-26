using System;
using System.Collections.Generic;
using NoWaste.Domain.Common;
using NoWaste.Domain.Models.Aggregates;
using NoWaste.Domain.Models.Contracts;

namespace NoWaste.Domain.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategories()
        {
            return Query<Category>("select * from Category");
        }

        public void DeleteAllCategories()
        {
             Query<Category>("Delete from Category");
        }

        public void DelteCategory(Category category)
        {
            Delete(category);

        }

        public void AddUpdateCategory(Category category)
        {
            if (category.Id > 0)
            {
                Update(category);
            }
            else
            {
                Insert(category);
            }
        }
    }
}
