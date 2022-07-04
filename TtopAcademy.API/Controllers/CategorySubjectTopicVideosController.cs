using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for CategorySubjectTopicVideos. </summary>
    public class CategorySubjectTopicVideosController : ApiController
    {
        private readonly ICategorySubjectTopicVideoRepository categorySubjectTopicRepository;

        /// <summary> Constructs a new CategorySubjectTopicVideos controller with given parameter. </summary>
        public CategorySubjectTopicVideosController(ICategorySubjectTopicVideoRepository categorySubjectTopicRepository)
        {
            this.categorySubjectTopicRepository = categorySubjectTopicRepository; 
        }

        /// <summary> Returns all CategorySubjectTopicVideos.
        ///     Route is GET: api/CategorySubjectTopicVideos </summary>
        public async Task<IEnumerable<CategorySubjectTopicVideo>> Get()
        {
            return await categorySubjectTopicRepository.GetAllAsync();
        }

        /// <summary> Returns all CategorySubjectTopicVideos for given CategorySubjectTopicID.
        ///     Route is GET: api/CategorySubjectTopicVideos/CategorySubjectTopicID </summary>
        public async Task<IEnumerable<CategorySubjectTopicVideo>> Get(int id)
        {
            return await categorySubjectTopicRepository.GetCategorySubjectTopicVideosAsync(id);
        }
        
    }
}
