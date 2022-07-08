using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for categories. </summary>
    [Authorize(Roles = "Adminstrator")] 
    public class CategoriesController : ApiController
    {
        private readonly ICategoryRepository repository;

        /// <summary> Constructs a new categories controller with given parameter. </summary>
        public CategoriesController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary> Returns all categories.
        ///     Route is GET: api/Categories </summary> 
        [AllowAnonymous] 
        public async Task<IEnumerable<Category>> Get()
        {
            return await repository.GetAllCategoriesAsync();
        }

        /// <summary> Saves the given data model. 
        ///     Route is POST: api/Categories. </summary> 
        public async Task<IHttpActionResult> Post(CategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category category = await repository.SaveCategoryAsync(new Category
            {
                Number = model.Number,
                Name = model.Name,
            });
            return Ok(category);
        }

        /// <summary> Updates the given data model with the specified categoryID. 
        ///     Route is PUT: api/Categories/CategoryID. </summary>
        public async Task<IHttpActionResult> Put(int id, CategoryBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await repository.UpdateCategoryAsync(new Category
            {
                CategoryID = id,
                Number = model.Number,
                Name = model.Name
            });
            return Ok();  
        }

        /// <summary> Deletes the category with given categoryID.
        ///     Route is DELETE: api/Categories/CategoryID </summary>  
        public async Task<IHttpActionResult> Delete(int id)
        {
            Category category = await repository.DeleteCategoryAsync(id);
            if (category == null)
            {
                return BadRequest("CategoryID is invalid");
            }
            return Ok();
        }
    }
}
