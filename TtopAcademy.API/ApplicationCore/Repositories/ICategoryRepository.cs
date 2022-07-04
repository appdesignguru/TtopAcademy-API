using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> Category repository interface. </summary>
    public interface ICategoryRepository
    {
        /// <summary> Returns all categories. </summary>
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        /// <summary> Returns saved category or null if saving not successful. </summary>
        Task<Category> SaveCategoryAsync(Category category);

        /// <summary> Returns updated category or null if the category
        ///     to be updated does not exist. </summary> 
        Task<Category> UpdateCategoryAsync(Category category);

        /// <summary> Returns deleted category or null if the category
        ///     to be deleted does not exist. </summary> 
        Task<Category> DeleteCategoryAsync(int categoryID);
    }
}
