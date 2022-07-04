using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public FakeCategoryRepository(List<Category> categories)
        {
            this.categories = categories;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync() 
        {
            return await Task.FromResult(categories);
        }

        public async Task<Category> DeleteCategoryAsync(int categoryID)
        {
            return await Task.FromResult(DeleteCategory(categoryID));
        }

        public async Task<Category> SaveCategoryAsync(Category category)
        {
            return await Task.FromResult(SaveCategory(category));
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await Task.FromResult(UpdateCategory(category));
        } 

        private Category DeleteCategory(int categoryID)
        {
            Category category = categories.FirstOrDefault(c => c.CategoryID == categoryID);
            if (category != null)
            {
                categories.Remove(category);
            }
            return category;
        }

        private Category SaveCategory(Category category)
        {
            Category entry = new Category
            {
                CategoryID = 100,
                Number = category.Number,
                Name = category.Name
            };
            categories.Add(entry);
            return entry; 
        }

        private Category UpdateCategory(Category category)
        {
            Category entry = categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (entry != null)
            {
                entry.CategoryID = category.CategoryID;
                entry.Number = category.Number;
                entry.Name = category.Name;
            }
            return entry; 
        }
    }
}