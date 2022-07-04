using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.ApplicationDbContext;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Real
{
    /// <summary> Category repository class. </summary> 
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private readonly IApplicationDbContext context;

        /// <summary> Constructs a new category repository with given parameter. </summary> 
        public CategoryRepository(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await Task.FromResult(context.Categories);
        } 

        public async Task<Category> DeleteCategoryAsync(int categoryID)
        {
            Category dbEntry = await context.Categories.FindAsync(categoryID);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public async Task<Category> SaveCategoryAsync(Category category)
        {
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return GetCategory(category.Name, category.Number);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            Category dbEntry = await context.Categories.FindAsync(category.CategoryID);
            if (dbEntry != null)
            {
                dbEntry.Number = category.Number;
                dbEntry.Name = category.Name;
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

        private Category GetCategory(string categoryName, int categoryNumber)
        {
            return context.Categories.FirstOrDefault(p => p.Name == categoryName
                                                       && p.Number == categoryNumber);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}