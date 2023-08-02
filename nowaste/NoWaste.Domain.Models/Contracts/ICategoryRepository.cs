using System;
using System.Collections.Generic;
using NoWaste.Domain.Models.Aggregates;

namespace NoWaste.Domain.Models.Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        void AddUpdateCategory(Category category);
        void DelteCategory(Category category);
        void DeleteAllCategories();
    }
}
